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
Imports ViVeTool_GUI.Wpf.Models

Namespace Services
    ''' <summary>
    ''' Service for managing Windows feature configurations.
    ''' Wraps future ViVe/RtlFeatureManager calls.
    ''' </summary>
    Public Class FeatureService
        ''' <summary>
        ''' Gets all available features from the system.
        ''' </summary>
        ''' <returns>A collection of feature items.</returns>
        Public Async Function GetFeaturesAsync() As Task(Of ObservableCollection(Of FeatureItem))
            ' TODO: Implement using Albacore.ViVe.RtlFeatureManager
            ' Example:
            ' Dim features = Albacore.ViVe.RtlFeatureManager.QueryAllFeatureConfigurations()
            ' Return features.Select(Function(f) New FeatureItem(f.FeatureId, f.FeatureName, ...))
            
            Await Task.Delay(100) ' Simulated async operation
            
            ' Return sample data for scaffold testing
            Return New ObservableCollection(Of FeatureItem)() From {
                New FeatureItem(12345678, "Sample Feature 1", "Enabled", True, "This is a sample feature for testing"),
                New FeatureItem(23456789, "Sample Feature 2", "Disabled", False, "Another sample feature"),
                New FeatureItem(34567890, "Sample Feature 3", "Default", False, "Feature with default state"),
                New FeatureItem(45678901, "Hidden Feature", "Enabled", True, "A hidden experimental feature"),
                New FeatureItem(56789012, "Test Feature", "Disabled", False, "For testing purposes only")
            }
        End Function

        ''' <summary>
        ''' Enables a specific feature.
        ''' </summary>
        ''' <param name="featureId">The feature ID to enable.</param>
        ''' <returns>True if successful, false otherwise.</returns>
        Public Async Function EnableFeatureAsync(featureId As Integer) As Task(Of Boolean)
            ' TODO: Implement using Albacore.ViVe.RtlFeatureManager
            ' Example:
            ' Albacore.ViVe.RtlFeatureManager.SetFeatureConfigurations(
            '     New Albacore.ViVe.FeatureConfiguration() With {
            '         .FeatureId = featureId,
            '         .EnabledState = Albacore.ViVe.FeatureEnabledState.Enabled
            '     })
            
            Await Task.Delay(100) ' Simulated async operation
            Return True
        End Function

        ''' <summary>
        ''' Disables a specific feature.
        ''' </summary>
        ''' <param name="featureId">The feature ID to disable.</param>
        ''' <returns>True if successful, false otherwise.</returns>
        Public Async Function DisableFeatureAsync(featureId As Integer) As Task(Of Boolean)
            ' TODO: Implement using Albacore.ViVe.RtlFeatureManager
            ' Example:
            ' Albacore.ViVe.RtlFeatureManager.SetFeatureConfigurations(
            '     New Albacore.ViVe.FeatureConfiguration() With {
            '         .FeatureId = featureId,
            '         .EnabledState = Albacore.ViVe.FeatureEnabledState.Disabled
            '     })
            
            Await Task.Delay(100) ' Simulated async operation
            Return True
        End Function

        ''' <summary>
        ''' Reverts a specific feature to its default state.
        ''' </summary>
        ''' <param name="featureId">The feature ID to revert.</param>
        ''' <returns>True if successful, false otherwise.</returns>
        Public Async Function RevertFeatureAsync(featureId As Integer) As Task(Of Boolean)
            ' TODO: Implement using Albacore.ViVe.RtlFeatureManager
            ' Example:
            ' Albacore.ViVe.RtlFeatureManager.DeleteFeatureConfigurations(featureId)
            
            Await Task.Delay(100) ' Simulated async operation
            Return True
        End Function

        ''' <summary>
        ''' Applies a feature configuration (enable or disable).
        ''' </summary>
        ''' <param name="featureId">The feature ID.</param>
        ''' <param name="enable">True to enable, false to disable.</param>
        ''' <returns>True if successful, false otherwise.</returns>
        Public Async Function ApplyFeatureAsync(featureId As Integer, enable As Boolean) As Task(Of Boolean)
            If enable Then
                Return Await EnableFeatureAsync(featureId)
            Else
                Return Await DisableFeatureAsync(featureId)
            End If
        End Function
    End Class
End Namespace
