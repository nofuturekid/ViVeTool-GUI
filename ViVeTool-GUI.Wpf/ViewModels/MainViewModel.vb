' ViVeTool-GUI - Windows Feature Control GUI for ViVeTool
' Copyright (C) 2022  Peter Strick / Peters Software Solutions
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <https://www.gnu.org/licenses/>.

Option Explicit On
Option Strict On

Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Data
Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input
Imports ViVeTool_GUI.Wpf.Models
Imports ViVeTool_GUI.Wpf.Services

Namespace ViewModels
    ''' <summary>
    ''' Main view model for the application.
    ''' </summary>
    Partial Public Class MainViewModel
        Inherits ObservableObject

        Private ReadOnly _featureService As FeatureService
        Private ReadOnly _gitHubService As GitHubService
        Private ReadOnly _themeService As ThemeService

        Private _features As ObservableCollection(Of FeatureItem)
        Private _featuresView As ICollectionView
        Private _selectedFeature As FeatureItem
        Private _searchText As String = String.Empty
        Private _selectedBuild As String = String.Empty
        Private _availableBuilds As ObservableCollection(Of String)
        Private _statusMessage As String = "Ready"
        Private _isLoading As Boolean
        Private _currentThemeName As String = "Light"

        ''' <summary>
        ''' Gets or sets the collection of features.
        ''' </summary>
        Public Property Features As ObservableCollection(Of FeatureItem)
            Get
                Return _features
            End Get
            Set(value As ObservableCollection(Of FeatureItem))
                SetProperty(_features, value)
            End Set
        End Property

        ''' <summary>
        ''' Gets the filtered view of features.
        ''' </summary>
        Public ReadOnly Property FeaturesView As ICollectionView
            Get
                Return _featuresView
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the currently selected feature.
        ''' </summary>
        Public Property SelectedFeature As FeatureItem
            Get
                Return _selectedFeature
            End Get
            Set(value As FeatureItem)
                If SetProperty(_selectedFeature, value) Then
                    ApplyFeatureCommand.NotifyCanExecuteChanged()
                    RevertFeatureCommand.NotifyCanExecuteChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the search text for filtering features.
        ''' </summary>
        Public Property SearchText As String
            Get
                Return _searchText
            End Get
            Set(value As String)
                If SetProperty(_searchText, value) Then
                    _featuresView?.Refresh()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the selected build number.
        ''' </summary>
        Public Property SelectedBuild As String
            Get
                Return _selectedBuild
            End Get
            Set(value As String)
                SetProperty(_selectedBuild, value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the available build numbers.
        ''' </summary>
        Public Property AvailableBuilds As ObservableCollection(Of String)
            Get
                Return _availableBuilds
            End Get
            Set(value As ObservableCollection(Of String))
                SetProperty(_availableBuilds, value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the status bar message.
        ''' </summary>
        Public Property StatusMessage As String
            Get
                Return _statusMessage
            End Get
            Set(value As String)
                SetProperty(_statusMessage, value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether a loading operation is in progress.
        ''' </summary>
        Public Property IsLoading As Boolean
            Get
                Return _isLoading
            End Get
            Set(value As Boolean)
                If SetProperty(_isLoading, value) Then
                    ApplyFeatureCommand.NotifyCanExecuteChanged()
                    RevertFeatureCommand.NotifyCanExecuteChanged()
                    RefreshBuildsCommand.NotifyCanExecuteChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the current theme name for display.
        ''' </summary>
        Public Property CurrentThemeName As String
            Get
                Return _currentThemeName
            End Get
            Set(value As String)
                SetProperty(_currentThemeName, value)
            End Set
        End Property

        ''' <summary>
        ''' Command to apply/enable a feature.
        ''' </summary>
        Public ReadOnly Property ApplyFeatureCommand As IRelayCommand

        ''' <summary>
        ''' Command to revert a feature to default.
        ''' </summary>
        Public ReadOnly Property RevertFeatureCommand As IRelayCommand

        ''' <summary>
        ''' Command to refresh the list of available builds.
        ''' </summary>
        Public ReadOnly Property RefreshBuildsCommand As IAsyncRelayCommand

        ''' <summary>
        ''' Command to toggle the application theme.
        ''' </summary>
        Public ReadOnly Property ToggleThemeCommand As IRelayCommand

        ''' <summary>
        ''' Command to load features.
        ''' </summary>
        Public ReadOnly Property LoadFeaturesCommand As IAsyncRelayCommand

        ''' <summary>
        ''' Creates a new instance of MainViewModel.
        ''' </summary>
        Public Sub New()
            _featureService = New FeatureService()
            _gitHubService = New GitHubService()
            _themeService = ThemeService.Instance

            _features = New ObservableCollection(Of FeatureItem)()
            _availableBuilds = New ObservableCollection(Of String)()

            ' Initialize the collection view for filtering
            _featuresView = CollectionViewSource.GetDefaultView(_features)
            _featuresView.Filter = AddressOf FilterFeatures

            ' Initialize commands
            ApplyFeatureCommand = New RelayCommand(AddressOf ExecuteApplyFeature, AddressOf CanExecuteFeatureCommand)
            RevertFeatureCommand = New RelayCommand(AddressOf ExecuteRevertFeature, AddressOf CanExecuteFeatureCommand)
            RefreshBuildsCommand = New AsyncRelayCommand(AddressOf ExecuteRefreshBuildsAsync, AddressOf CanExecuteRefreshBuilds)
            ToggleThemeCommand = New RelayCommand(AddressOf ExecuteToggleTheme)
            LoadFeaturesCommand = New AsyncRelayCommand(AddressOf ExecuteLoadFeaturesAsync)

            ' Set initial theme name
            _currentThemeName = _themeService.CurrentTheme
        End Sub

        ''' <summary>
        ''' Filter predicate for the features collection.
        ''' </summary>
        Private Function FilterFeatures(item As Object) As Boolean
            If item Is Nothing Then
                Return False
            End If

            Dim feature = TryCast(item, FeatureItem)
            If feature Is Nothing Then
                Return False
            End If

            If String.IsNullOrWhiteSpace(SearchText) Then
                Return True
            End If

            ' Filter by name, ID, or notes
            Dim searchLower = SearchText.ToLowerInvariant()
            Return feature.Name.ToLowerInvariant().Contains(searchLower) OrElse
                   feature.Id.ToString().Contains(searchLower) OrElse
                   (Not String.IsNullOrEmpty(feature.Notes) AndAlso feature.Notes.ToLowerInvariant().Contains(searchLower))
        End Function

        ''' <summary>
        ''' Determines if feature commands can execute.
        ''' </summary>
        Private Function CanExecuteFeatureCommand() As Boolean
            Return SelectedFeature IsNot Nothing AndAlso Not IsLoading
        End Function

        ''' <summary>
        ''' Determines if refresh builds command can execute.
        ''' </summary>
        Private Function CanExecuteRefreshBuilds() As Boolean
            Return Not IsLoading
        End Function

        ''' <summary>
        ''' Executes the apply feature command.
        ''' </summary>
        Private Async Sub ExecuteApplyFeature()
            If SelectedFeature Is Nothing Then Return

            Try
                IsLoading = True
                StatusMessage = $"Applying feature {SelectedFeature.Id}..."

                ' TODO: Determine enable/disable based on UI state or show dialog
                Dim result = Await _featureService.ApplyFeatureAsync(SelectedFeature.Id, True)

                If result Then
                    SelectedFeature.IsEnabled = True
                    SelectedFeature.State = "Enabled"
                    StatusMessage = $"Feature {SelectedFeature.Id} applied successfully."
                Else
                    StatusMessage = $"Failed to apply feature {SelectedFeature.Id}."
                End If
            Catch ex As Exception
                StatusMessage = $"Error: {ex.Message}"
            Finally
                IsLoading = False
            End Try
        End Sub

        ''' <summary>
        ''' Executes the revert feature command.
        ''' </summary>
        Private Async Sub ExecuteRevertFeature()
            If SelectedFeature Is Nothing Then Return

            Try
                IsLoading = True
                StatusMessage = $"Reverting feature {SelectedFeature.Id}..."

                Dim result = Await _featureService.RevertFeatureAsync(SelectedFeature.Id)

                If result Then
                    SelectedFeature.IsEnabled = False
                    SelectedFeature.State = "Default"
                    StatusMessage = $"Feature {SelectedFeature.Id} reverted successfully."
                Else
                    StatusMessage = $"Failed to revert feature {SelectedFeature.Id}."
                End If
            Catch ex As Exception
                StatusMessage = $"Error: {ex.Message}"
            Finally
                IsLoading = False
            End Try
        End Sub

        ''' <summary>
        ''' Executes the refresh builds command asynchronously.
        ''' </summary>
        Private Async Function ExecuteRefreshBuildsAsync() As Task
            Try
                IsLoading = True
                StatusMessage = "Fetching available builds..."

                Dim builds = Await _gitHubService.GetAvailableBuildsAsync()

                AvailableBuilds.Clear()
                For Each build In builds
                    AvailableBuilds.Add(build)
                Next

                If AvailableBuilds.Count > 0 Then
                    SelectedBuild = AvailableBuilds(0)
                End If

                StatusMessage = $"Found {AvailableBuilds.Count} builds."
            Catch ex As Exception
                StatusMessage = $"Error fetching builds: {ex.Message}"
            Finally
                IsLoading = False
            End Try
        End Function

        ''' <summary>
        ''' Executes the toggle theme command.
        ''' </summary>
        Private Sub ExecuteToggleTheme()
            _themeService.ToggleTheme()
            CurrentThemeName = _themeService.CurrentTheme
            StatusMessage = $"Theme changed to {CurrentThemeName}."
        End Sub

        ''' <summary>
        ''' Loads features asynchronously.
        ''' </summary>
        Private Async Function ExecuteLoadFeaturesAsync() As Task
            Try
                IsLoading = True
                StatusMessage = "Loading features..."

                Dim loadedFeatures = Await _featureService.GetFeaturesAsync()

                Features.Clear()
                For Each feature In loadedFeatures
                    Features.Add(feature)
                Next

                StatusMessage = $"Loaded {Features.Count} features."
            Catch ex As Exception
                StatusMessage = $"Error loading features: {ex.Message}"
            Finally
                IsLoading = False
            End Try
        End Function

        ''' <summary>
        ''' Initializes the view model and loads initial data.
        ''' </summary>
        Public Async Function InitializeAsync() As Task
            Await ExecuteLoadFeaturesAsync()
            Await ExecuteRefreshBuildsAsync()
        End Function
    End Class
End Namespace
