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

Imports System.Windows

Namespace Services
    ''' <summary>
    ''' Service for managing application themes (Light/Dark).
    ''' </summary>
    Public Class ThemeService
        Private Shared _instance As ThemeService
        Private Shared ReadOnly _lock As New Object()
        
        Private _currentTheme As String = "Light"
        
        ''' <summary>
        ''' Gets the singleton instance of ThemeService.
        ''' </summary>
        Public Shared ReadOnly Property Instance As ThemeService
            Get
                If _instance Is Nothing Then
                    SyncLock _lock
                        If _instance Is Nothing Then
                            _instance = New ThemeService()
                        End If
                    End SyncLock
                End If
                Return _instance
            End Get
        End Property

        ''' <summary>
        ''' Gets the current theme name.
        ''' </summary>
        Public ReadOnly Property CurrentTheme As String
            Get
                Return _currentTheme
            End Get
        End Property

        ''' <summary>
        ''' Private constructor for singleton pattern.
        ''' </summary>
        Private Sub New()
        End Sub

        ''' <summary>
        ''' Applies the specified theme to the application.
        ''' </summary>
        ''' <param name="themeName">The theme name ("Light" or "Dark").</param>
        Public Sub ApplyTheme(themeName As String)
            If String.IsNullOrEmpty(themeName) Then
                themeName = "Light"
            End If

            Dim themeUri As Uri
            Select Case themeName.ToUpperInvariant()
                Case "DARK"
                    themeUri = New Uri("pack://application:,,,/ViVeTool-GUI.Wpf;component/Themes/Dark.xaml", UriKind.Absolute)
                    _currentTheme = "Dark"
                Case Else
                    themeUri = New Uri("pack://application:,,,/ViVeTool-GUI.Wpf;component/Themes/Light.xaml", UriKind.Absolute)
                    _currentTheme = "Light"
            End Select

            Dim themeDictionary As New ResourceDictionary()
            themeDictionary.Source = themeUri

            ' Remove any existing theme dictionaries and add the new one
            Dim mergedDictionaries = Application.Current.Resources.MergedDictionaries
            
            ' Find and remove existing theme dictionary
            Dim existingTheme = mergedDictionaries.FirstOrDefault(Function(d) 
                Return d.Source IsNot Nothing AndAlso 
                       (d.Source.ToString().Contains("Themes/Light.xaml") OrElse 
                        d.Source.ToString().Contains("Themes/Dark.xaml"))
            End Function)

            If existingTheme IsNot Nothing Then
                mergedDictionaries.Remove(existingTheme)
            End If

            ' Add the new theme dictionary
            mergedDictionaries.Add(themeDictionary)

            ' TODO: Persist theme choice to user settings
            ' Example: My.Settings.Theme = themeName
            ' My.Settings.Save()
        End Sub

        ''' <summary>
        ''' Toggles between Light and Dark themes.
        ''' </summary>
        Public Sub ToggleTheme()
            If _currentTheme = "Light" Then
                ApplyTheme("Dark")
            Else
                ApplyTheme("Light")
            End If
        End Sub

        ''' <summary>
        ''' Loads the saved theme preference and applies it.
        ''' </summary>
        Public Sub LoadSavedTheme()
            ' TODO: Load theme from persisted settings
            ' Example: Dim savedTheme = My.Settings.Theme
            ' If String.IsNullOrEmpty(savedTheme) Then savedTheme = "Light"
            ' ApplyTheme(savedTheme)
            
            ' For now, default to Light theme
            ApplyTheme("Light")
        End Sub
    End Class
End Namespace
