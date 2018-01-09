<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FormCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormCustomerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormVehicleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormTransaksiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormCustomerToolStripMenuItem, Me.ExitToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.Name = "MenuStrip"
        '
        'FormCustomerToolStripMenuItem
        '
        Me.FormCustomerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FormCustomerToolStripMenuItem.DoubleClickEnabled = True
        Me.FormCustomerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormCustomerToolStripMenuItem1, Me.FormVehicleToolStripMenuItem1, Me.FormTransaksiToolStripMenuItem1})
        Me.FormCustomerToolStripMenuItem.Name = "FormCustomerToolStripMenuItem"
        resources.ApplyResources(Me.FormCustomerToolStripMenuItem, "FormCustomerToolStripMenuItem")
        '
        'FormCustomerToolStripMenuItem1
        '
        Me.FormCustomerToolStripMenuItem1.Name = "FormCustomerToolStripMenuItem1"
        resources.ApplyResources(Me.FormCustomerToolStripMenuItem1, "FormCustomerToolStripMenuItem1")
        '
        'FormVehicleToolStripMenuItem1
        '
        Me.FormVehicleToolStripMenuItem1.Name = "FormVehicleToolStripMenuItem1"
        resources.ApplyResources(Me.FormVehicleToolStripMenuItem1, "FormVehicleToolStripMenuItem1")
        '
        'FormTransaksiToolStripMenuItem1
        '
        Me.FormTransaksiToolStripMenuItem1.Name = "FormTransaksiToolStripMenuItem1"
        resources.ApplyResources(Me.FormTransaksiToolStripMenuItem1, "FormTransaksiToolStripMenuItem1")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'Menu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FormCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormCustomerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormVehicleToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormTransaksiToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
