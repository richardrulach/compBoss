<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProjectDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewProjectDialog))
        Me.btnCreateNewProject = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnCancelNewProject = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCreateNewProject
        '
        Me.btnCreateNewProject.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCreateNewProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateNewProject.Location = New System.Drawing.Point(313, 10)
        Me.btnCreateNewProject.Name = "btnCreateNewProject"
        Me.btnCreateNewProject.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateNewProject.TabIndex = 0
        Me.btnCreateNewProject.Text = "Create"
        Me.btnCreateNewProject.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(13, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(294, 20)
        Me.TextBox1.TabIndex = 1
        '
        'btnCancelNewProject
        '
        Me.btnCancelNewProject.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelNewProject.Location = New System.Drawing.Point(394, 10)
        Me.btnCancelNewProject.Name = "btnCancelNewProject"
        Me.btnCancelNewProject.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelNewProject.TabIndex = 2
        Me.btnCancelNewProject.Text = "Cancel"
        Me.btnCancelNewProject.UseVisualStyleBackColor = True
        '
        'frmNewProjectDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 43)
        Me.Controls.Add(Me.btnCancelNewProject)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnCreateNewProject)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNewProjectDialog"
        Me.Text = "New Project Name"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreateNewProject As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelNewProject As System.Windows.Forms.Button
End Class
