<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompressionBoss
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompressionBoss))
        Me.btnAddFiles = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnRunCompression = New System.Windows.Forms.Button()
        Me.cmbAvailableProjects = New System.Windows.Forms.ComboBox()
        Me.btnSaveAsNewProject = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddFiles
        '
        Me.btnAddFiles.Location = New System.Drawing.Point(12, 12)
        Me.btnAddFiles.Name = "btnAddFiles"
        Me.btnAddFiles.Size = New System.Drawing.Size(118, 23)
        Me.btnAddFiles.TabIndex = 0
        Me.btnAddFiles.Text = "Add File/s"
        Me.btnAddFiles.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Location = New System.Drawing.Point(14, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 248)
        Me.Panel1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(709, 242)
        Me.DataGridView1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(654, 11)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnRunCompression
        '
        Me.btnRunCompression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunCompression.Location = New System.Drawing.Point(544, 11)
        Me.btnRunCompression.Name = "btnRunCompression"
        Me.btnRunCompression.Size = New System.Drawing.Size(104, 23)
        Me.btnRunCompression.TabIndex = 4
        Me.btnRunCompression.Text = "Run"
        Me.btnRunCompression.UseVisualStyleBackColor = True
        '
        'cmbAvailableProjects
        '
        Me.cmbAvailableProjects.FormattingEnabled = True
        Me.cmbAvailableProjects.Location = New System.Drawing.Point(136, 13)
        Me.cmbAvailableProjects.Name = "cmbAvailableProjects"
        Me.cmbAvailableProjects.Size = New System.Drawing.Size(175, 21)
        Me.cmbAvailableProjects.TabIndex = 6
        Me.cmbAvailableProjects.Text = "Choose from available projects"
        '
        'btnSaveAsNewProject
        '
        Me.btnSaveAsNewProject.Location = New System.Drawing.Point(317, 11)
        Me.btnSaveAsNewProject.Name = "btnSaveAsNewProject"
        Me.btnSaveAsNewProject.Size = New System.Drawing.Size(133, 23)
        Me.btnSaveAsNewProject.TabIndex = 7
        Me.btnSaveAsNewProject.Text = "Save as new project"
        Me.btnSaveAsNewProject.UseVisualStyleBackColor = True
        '
        'frmCompressionBoss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 299)
        Me.Controls.Add(Me.btnSaveAsNewProject)
        Me.Controls.Add(Me.cmbAvailableProjects)
        Me.Controls.Add(Me.btnRunCompression)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAddFiles)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCompressionBoss"
        Me.Text = "Compression Boss"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddFiles As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnRunCompression As System.Windows.Forms.Button
    Friend WithEvents cmbAvailableProjects As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveAsNewProject As System.Windows.Forms.Button

End Class
