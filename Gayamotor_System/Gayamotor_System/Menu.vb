Imports System.Windows.Forms

Public Class Menu
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub FormCustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormCustomerToolStripMenuItem1.Click
        Customer_master.MdiParent = Me
        Customer_master.Dock = DockStyle.Fill
        Customer_master.Show()
    End Sub

    Private Sub FormVehicleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormVehicleToolStripMenuItem1.Click
        Vehicle_master.MdiParent = Me
        Vehicle_master.Dock = DockStyle.Fill
        Vehicle_master.Show()
    End Sub

    Private Sub FormTransaksiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormTransaksiToolStripMenuItem1.Click
        Transaction_master2.MdiParent = Me
        Transaction_master2.Dock = DockStyle.Fill
        Transaction_master2.Show()
    End Sub

End Class
