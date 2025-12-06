<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GUI

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI))
        Me.RDDL_Build = New System.Windows.Forms.ComboBox()
        Me.RSS_MainStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.RLE_StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RGV_MainGridView = New System.Windows.Forms.DataGridView()
        Me.FeatureName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeatureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeatureState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeatureInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BGW_PopulateGridView = New System.ComponentModel.BackgroundWorker()
        Me.P_CommandPanel = New System.Windows.Forms.Panel()
        Me.RL_BuildComboBoxORManaully = New System.Windows.Forms.Label()
        Me.RB_ManuallySetFeature = New System.Windows.Forms.Button()
        Me.RB_About = New System.Windows.Forms.Button()
        Me.RDDB_PerformAction = New System.Windows.Forms.Button()
        Me.ActionContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RMI_ActivateF = New System.Windows.Forms.ToolStripMenuItem()
        Me.RMI_DeactivateF = New System.Windows.Forms.ToolStripMenuItem()
        Me.RMI_RevertF = New System.Windows.Forms.ToolStripMenuItem()
        Me.P_DataPanel = New System.Windows.Forms.Panel()
        Me.SearchPanel = New System.Windows.Forms.Panel()
        Me.TB_Search = New System.Windows.Forms.TextBox()
        Me.LBL_Search = New System.Windows.Forms.Label()
        Me.RSS_MainStatusStrip.SuspendLayout()
        CType(Me.RGV_MainGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P_CommandPanel.SuspendLayout()
        Me.ActionContextMenu.SuspendLayout()
        Me.P_DataPanel.SuspendLayout()
        Me.SearchPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RDDL_Build
        '
        Me.RDDL_Build.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RDDL_Build.Enabled = False
        Me.RDDL_Build.Location = New System.Drawing.Point(3, 5)
        Me.RDDL_Build.Name = "RDDL_Build"
        Me.RDDL_Build.Size = New System.Drawing.Size(125, 24)
        Me.RDDL_Build.Sorted = True
        Me.RDDL_Build.TabIndex = 0
        '
        'RSS_MainStatusStrip
        '
        Me.RSS_MainStatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RSS_MainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RLE_StatusLabel})
        Me.RSS_MainStatusStrip.Location = New System.Drawing.Point(0, 543)
        Me.RSS_MainStatusStrip.Name = "RSS_MainStatusStrip"
        Me.RSS_MainStatusStrip.Size = New System.Drawing.Size(792, 24)
        Me.RSS_MainStatusStrip.SizingGrip = False
        Me.RSS_MainStatusStrip.TabIndex = 3
        '
        'RLE_StatusLabel
        '
        Me.RLE_StatusLabel.Name = "RLE_StatusLabel"
        Me.RLE_StatusLabel.Size = New System.Drawing.Size(777, 19)
        Me.RLE_StatusLabel.Spring = True
        Me.RLE_StatusLabel.Text = "Populating the Build Combo Box..."
        Me.RLE_StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RGV_MainGridView
        '
        Me.RGV_MainGridView.AllowUserToAddRows = False
        Me.RGV_MainGridView.AllowUserToDeleteRows = False
        Me.RGV_MainGridView.AllowUserToOrderColumns = False
        Me.RGV_MainGridView.AllowUserToResizeColumns = False
        Me.RGV_MainGridView.AllowUserToResizeRows = False
        Me.RGV_MainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RGV_MainGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FeatureName, Me.FeatureID, Me.FeatureState, Me.FeatureInfo})
        Me.RGV_MainGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RGV_MainGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.RGV_MainGridView.Location = New System.Drawing.Point(0, 30)
        Me.RGV_MainGridView.MultiSelect = False
        Me.RGV_MainGridView.Name = "RGV_MainGridView"
        Me.RGV_MainGridView.ReadOnly = True
        Me.RGV_MainGridView.RowHeadersVisible = False
        Me.RGV_MainGridView.RowHeadersWidth = 51
        Me.RGV_MainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RGV_MainGridView.Size = New System.Drawing.Size(792, 475)
        Me.RGV_MainGridView.TabIndex = 5
        '
        'FeatureName
        '
        Me.FeatureName.HeaderText = "Feature Name"
        Me.FeatureName.MinimumWidth = 6
        Me.FeatureName.Name = "FeatureName"
        Me.FeatureName.ReadOnly = True
        Me.FeatureName.Width = 535
        '
        'FeatureID
        '
        Me.FeatureID.HeaderText = "Feature ID"
        Me.FeatureID.MinimumWidth = 6
        Me.FeatureID.Name = "FeatureID"
        Me.FeatureID.ReadOnly = True
        Me.FeatureID.Width = 80
        '
        'FeatureState
        '
        Me.FeatureState.HeaderText = "Feature State"
        Me.FeatureState.MinimumWidth = 6
        Me.FeatureState.Name = "FeatureState"
        Me.FeatureState.ReadOnly = True
        Me.FeatureState.Width = 100
        '
        'FeatureInfo
        '
        Me.FeatureInfo.HeaderText = "Features that are"
        Me.FeatureInfo.MinimumWidth = 6
        Me.FeatureInfo.Name = "FeatureInfo"
        Me.FeatureInfo.ReadOnly = True
        Me.FeatureInfo.Visible = False
        Me.FeatureInfo.Width = 20
        '
        'BGW_PopulateGridView
        '
        Me.BGW_PopulateGridView.WorkerSupportsCancellation = True
        '
        'P_CommandPanel
        '
        Me.P_CommandPanel.Controls.Add(Me.RL_BuildComboBoxORManaully)
        Me.P_CommandPanel.Controls.Add(Me.RB_ManuallySetFeature)
        Me.P_CommandPanel.Controls.Add(Me.RB_About)
        Me.P_CommandPanel.Controls.Add(Me.RDDL_Build)
        Me.P_CommandPanel.Controls.Add(Me.RDDB_PerformAction)
        Me.P_CommandPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_CommandPanel.Location = New System.Drawing.Point(0, 0)
        Me.P_CommandPanel.Name = "P_CommandPanel"
        Me.P_CommandPanel.Size = New System.Drawing.Size(792, 38)
        Me.P_CommandPanel.TabIndex = 6
        '
        'RL_BuildComboBoxORManaully
        '
        Me.RL_BuildComboBoxORManaully.AutoSize = True
        Me.RL_BuildComboBoxORManaully.Location = New System.Drawing.Point(145, 10)
        Me.RL_BuildComboBoxORManaully.Name = "RL_BuildComboBoxORManaully"
        Me.RL_BuildComboBoxORManaully.Size = New System.Drawing.Size(18, 17)
        Me.RL_BuildComboBoxORManaully.TabIndex = 9
        Me.RL_BuildComboBoxORManaully.Text = "or"
        '
        'RB_ManuallySetFeature
        '
        Me.RB_ManuallySetFeature.Image = Global.ViVeTool_GUI.My.Resources.Resources.icons8_registration_24px
        Me.RB_ManuallySetFeature.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RB_ManuallySetFeature.Location = New System.Drawing.Point(181, 4)
        Me.RB_ManuallySetFeature.Name = "RB_ManuallySetFeature"
        Me.RB_ManuallySetFeature.Size = New System.Drawing.Size(212, 30)
        Me.RB_ManuallySetFeature.TabIndex = 8
        Me.RB_ManuallySetFeature.Text = "Manually change a Feature (F12)"
        Me.RB_ManuallySetFeature.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RB_ManuallySetFeature.UseVisualStyleBackColor = True
        '
        'RB_About
        '
        Me.RB_About.Image = Global.ViVeTool_GUI.My.Resources.Resources.icons8_about_24
        Me.RB_About.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RB_About.Location = New System.Drawing.Point(610, 4)
        Me.RB_About.Name = "RB_About"
        Me.RB_About.Size = New System.Drawing.Size(158, 30)
        Me.RB_About.TabIndex = 4
        Me.RB_About.Text = "  About && Settings"
        Me.RB_About.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RB_About.UseVisualStyleBackColor = True
        '
        'RDDB_PerformAction
        '
        Me.RDDB_PerformAction.Enabled = False
        Me.RDDB_PerformAction.Image = Global.ViVeTool_GUI.My.Resources.Resources.icons8_start_24
        Me.RDDB_PerformAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RDDB_PerformAction.Location = New System.Drawing.Point(432, 4)
        Me.RDDB_PerformAction.Name = "RDDB_PerformAction"
        Me.RDDB_PerformAction.Size = New System.Drawing.Size(154, 30)
        Me.RDDB_PerformAction.TabIndex = 2
        Me.RDDB_PerformAction.Text = "Perform Action ▼"
        Me.RDDB_PerformAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RDDB_PerformAction.UseVisualStyleBackColor = True
        '
        'ActionContextMenu
        '
        Me.ActionContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ActionContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RMI_ActivateF, Me.RMI_DeactivateF, Me.RMI_RevertF})
        Me.ActionContextMenu.Name = "ActionContextMenu"
        Me.ActionContextMenu.Size = New System.Drawing.Size(250, 76)
        '
        'RMI_ActivateF
        '
        Me.RMI_ActivateF.Image = Global.ViVeTool_GUI.My.Resources.Resources.icons8_toggle_on_24
        Me.RMI_ActivateF.Name = "RMI_ActivateF"
        Me.RMI_ActivateF.Size = New System.Drawing.Size(249, 24)
        Me.RMI_ActivateF.Text = "  Activate Feature"
        '
        'RMI_DeactivateF
        '
        Me.RMI_DeactivateF.Image = Global.ViVeTool_GUI.My.Resources.Resources.icons8_toggle_off_24
        Me.RMI_DeactivateF.Name = "RMI_DeactivateF"
        Me.RMI_DeactivateF.Size = New System.Drawing.Size(249, 24)
        Me.RMI_DeactivateF.Text = "  Deactivate Feature"
        '
        'RMI_RevertF
        '
        Me.RMI_RevertF.Image = Global.ViVeTool_GUI.My.Resources.Resources.icons8_rollback_24
        Me.RMI_RevertF.Name = "RMI_RevertF"
        Me.RMI_RevertF.Size = New System.Drawing.Size(249, 24)
        Me.RMI_RevertF.Text = "  Revert Feature to Default Values"
        '
        'P_DataPanel
        '
        Me.P_DataPanel.Controls.Add(Me.RGV_MainGridView)
        Me.P_DataPanel.Controls.Add(Me.SearchPanel)
        Me.P_DataPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P_DataPanel.Location = New System.Drawing.Point(0, 38)
        Me.P_DataPanel.Name = "P_DataPanel"
        Me.P_DataPanel.Size = New System.Drawing.Size(792, 505)
        Me.P_DataPanel.TabIndex = 7
        '
        'SearchPanel
        '
        Me.SearchPanel.Controls.Add(Me.TB_Search)
        Me.SearchPanel.Controls.Add(Me.LBL_Search)
        Me.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SearchPanel.Location = New System.Drawing.Point(0, 0)
        Me.SearchPanel.Name = "SearchPanel"
        Me.SearchPanel.Size = New System.Drawing.Size(792, 30)
        Me.SearchPanel.TabIndex = 6
        '
        'TB_Search
        '
        Me.TB_Search.Location = New System.Drawing.Point(60, 4)
        Me.TB_Search.Name = "TB_Search"
        Me.TB_Search.Size = New System.Drawing.Size(300, 22)
        Me.TB_Search.TabIndex = 1
        '
        'LBL_Search
        '
        Me.LBL_Search.AutoSize = True
        Me.LBL_Search.Location = New System.Drawing.Point(6, 7)
        Me.LBL_Search.Name = "LBL_Search"
        Me.LBL_Search.Size = New System.Drawing.Size(53, 17)
        Me.LBL_Search.TabIndex = 0
        Me.LBL_Search.Text = "Search:"
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 567)
        Me.Controls.Add(Me.P_DataPanel)
        Me.Controls.Add(Me.P_CommandPanel)
        Me.Controls.Add(Me.RSS_MainStatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "GUI"
        Me.Text = "ViVeTool GUI"
        Me.RSS_MainStatusStrip.ResumeLayout(False)
        Me.RSS_MainStatusStrip.PerformLayout()
        CType(Me.RGV_MainGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P_CommandPanel.ResumeLayout(False)
        Me.P_CommandPanel.PerformLayout()
        Me.ActionContextMenu.ResumeLayout(False)
        Me.P_DataPanel.ResumeLayout(False)
        Me.SearchPanel.ResumeLayout(False)
        Me.SearchPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RDDL_Build As System.Windows.Forms.ComboBox
    Friend WithEvents RSS_MainStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents RLE_StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RGV_MainGridView As System.Windows.Forms.DataGridView
    Friend WithEvents FeatureName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeatureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeatureState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeatureInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BGW_PopulateGridView As System.ComponentModel.BackgroundWorker
    Friend WithEvents P_CommandPanel As Panel
    Friend WithEvents P_DataPanel As Panel
    Friend WithEvents RB_About As System.Windows.Forms.Button
    Friend WithEvents RB_ManuallySetFeature As System.Windows.Forms.Button
    Friend WithEvents RL_BuildComboBoxORManaully As System.Windows.Forms.Label
    Friend WithEvents RDDB_PerformAction As System.Windows.Forms.Button
    Friend WithEvents ActionContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RMI_ActivateF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMI_DeactivateF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RMI_RevertF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchPanel As System.Windows.Forms.Panel
    Friend WithEvents TB_Search As System.Windows.Forms.TextBox
    Friend WithEvents LBL_Search As System.Windows.Forms.Label
End Class
