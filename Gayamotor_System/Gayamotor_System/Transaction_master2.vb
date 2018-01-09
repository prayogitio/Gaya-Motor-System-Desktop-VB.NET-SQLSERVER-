Imports System.Data.SqlClient
Public Class Transaction_master2
    Dim con As New SqlConnection("Data Source=(local)\SQLEXPRESS3;" +
                             "Initial Catalog=gayamotor;" +
                             "Integrated Security=True;")
    Dim sql As String
    Dim cmd As SqlCommand
    Dim databaru As Boolean

    Sub aktif_komponen(ByVal x As Boolean)
        btnTambah.Enabled = Not x
        btnEdit.Enabled = Not x
        btnClearAll.Enabled = Not x
        btnKeluar.Enabled = Not x
        btnSimpan.Enabled = x
        btnBatal.Enabled = x
        btnClearAll.Enabled = Not x
        btnKeluar.Enabled = Not x
        
        txtNoTransaksi.Enabled = False
        cboJenis.Enabled = x
        cboLeasing.Enabled = x
        dtpTanggalTransaksi.Enabled = False
        txtOtr.Enabled = x
        txtDp.Enabled = x
        txtBesarPinjaman.Enabled = x
        txtAngsuran.Enabled = x
        cboTenor.Enabled = x
        txtKeterangan.Enabled = x
        cboStatusTransaksi.Enabled = x
        txtCariCustomer.Enabled = x
        txtCariNoPol.Enabled = x

        txtCariCustomer.Text = ""
        txtCariNoPol.Text = ""
        If x = False Then
            muat_data1()
            muat_data2()
            muat_data3()
        End If

    End Sub

    Sub data_baru()
        Dim y As Integer
        y = drgTransaction.RowCount
        txtNoTransaksi.Text = y

        txtCustId.Text = ""
        txtNamaCust.Text = ""
        txtNikCust.Text = ""
        txtNomorPolisi.Text = ""
        txtMerk.Text = ""
        txtType.Text = ""
        txtCariCustomer.Text = ""
        txtCariNoPol.Text = ""
        cboJenis.SelectedIndex = -1
        cboLeasing.SelectedIndex = -1
        txtOtr.Text = ""
        txtDp.Text = ""
        txtBesarPinjaman.Text = ""
        txtAngsuran.Text = ""
        cboTenor.SelectedIndex = -1
        txtKeterangan.Text = ""
        cboStatusTransaksi.SelectedIndex = -1
        dtpTanggalTransaksi.Value = Date.Now
        txtCariCustomer.Focus()
    End Sub

    Sub muat_data1()
        sql = "SELECT * FROM tblkendaraan where nomor_polisi like '%" + txtCariNoPol.Text + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgVehicle.DataSource = dt
    End Sub

    Sub muat_data2()
        sql = "SELECT * FROM tblcustomer where nama like '%" + txtCariCustomer.Text + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgCustomer.DataSource = dt
    End Sub

    Sub muat_data3()
        sql = "SELECT * FROM tbltransaksi where nama like '%" + txtCariCustomer.Text + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgTransaction.DataSource = dt
    End Sub

    Sub muat_data4()
        sql = "SELECT * FROM tbltransaksi where nama like '%" + txtNamaCust2.Text + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgTransaction.DataSource = dt
    End Sub

    Sub muat_data5()
        sql = "SELECT * FROM tbltransaksi where nomor_polisi like '%" + txtNomorPolisi2.Text + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgTransaction.DataSource = dt
    End Sub

    Sub muat_data6()
        sql = "SELECT * FROM tbltransaksi where leasing like '%" + cboLeasing2.SelectedItem + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgTransaction.DataSource = dt
    End Sub

    Sub muat_data7()
        sql = "SELECT * FROM tbltransaksi where status_transaksi like '%" + cboStatus2.SelectedItem + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgTransaction.DataSource = dt
    End Sub

    Sub muat_data8()
        sql = "SELECT * FROM tbltransaksi where tgl_transaksi like '%" + dtpTanggal.Value.ToString("yyyy-MM-dd") + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgTransaction.DataSource = dt
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        aktif_komponen(False)
    End Sub

    Private Sub Customer_master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aktif_komponen(False)
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        databaru = True
        aktif_komponen(True)
        data_baru()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        databaru = False
        btnTambah.Enabled = False
        btnEdit.Enabled = False
        btnClearAll.Enabled = False
        btnKeluar.Enabled = False
        btnBatal.Enabled = True
        btnSimpan.Enabled = True
        txtNomorPolisi.Enabled = False
        cboJenis.Enabled = True
        cboLeasing.Enabled = True
        txtOtr.Enabled = True
        txtDp.Enabled = True
        txtBesarPinjaman.Enabled = True
        txtAngsuran.Enabled = True
        cboTenor.Enabled = True
        txtKeterangan.Enabled = True
        cboStatusTransaksi.Enabled = True
        cboJenis.Focus()
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub txtCariCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCariCustomer.TextChanged
        muat_data2()
    End Sub

    Private Sub txtCariNoPol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCariNoPol.TextChanged
        muat_data1()
    End Sub

    Private Sub btnBatal_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        aktif_komponen(False)
    End Sub

    Function validasi_data() As Boolean
        Dim hasil As Boolean = True

        If txtCustId.Text = "" Then hasil = False
        If txtNamaCust.Text = "" Then hasil = False
        If txtNikCust.Text = "" Then hasil = False
        If txtNomorPolisi.Text = "" Then hasil = False
        If txtMerk.Text = "" Then hasil = False
        If txtType.Text = "" Then hasil = False
        If txtNoTransaksi.Text = "" Then hasil = False
        If txtOtr.Text = "" Then hasil = False
        If txtDp.Text = "" Then hasil = False
        If txtBesarPinjaman.Text = "" Then hasil = False
        If txtAngsuran.Text = "" Then hasil = False
        If cboTenor.Text = "" Then hasil = False
        If cboJenis.Text = "" Then hasil = False
        If cboLeasing.Text = "" Then hasil = False
        If cboStatusTransaksi.Text = "" Then hasil = False
        If txtKeterangan.Text = "" Then hasil = False

        Return hasil
    End Function

    Function eksekusi_query(ByVal sql As String, ByVal hapus As Boolean) As Boolean
        Dim hasil As Boolean

        Try
            con.Open()
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql

                If hapus = False Then
                    .Parameters.AddWithValue("p1", txtNoTransaksi.Text)
                    .Parameters.AddWithValue("p2", cboJenis.Text)
                    .Parameters.AddWithValue("p3", cboLeasing.Text)
                    .Parameters.AddWithValue("p4", txtCustId.Text)
                    .Parameters.AddWithValue("p5", txtNamaCust.Text)
                    .Parameters.AddWithValue("p6", txtNomorPolisi.Text)
                    .Parameters.AddWithValue("p7", txtOtr.Text)
                    .Parameters.AddWithValue("p8", txtDp.Text)
                    .Parameters.AddWithValue("p9", txtBesarPinjaman.Text)
                    .Parameters.AddWithValue("p10", txtAngsuran.Text)
                    .Parameters.AddWithValue("p11", cboTenor.Text)
                    .Parameters.AddWithValue("p12", dtpTanggalTransaksi.Value)
                    .Parameters.AddWithValue("p13", txtKeterangan.Text)
                    .Parameters.AddWithValue("p14", cboStatusTransaksi.Text)
                Else
                    .Parameters.AddWithValue("p1", txtNoTransaksi.Text)
                End If

                If .ExecuteNonQuery Then
                    hasil = True
                End If
            End With
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ex.Source)
            con.Close()
        End Try
        Return hasil
    End Function

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click

        If validasi_data() = False Then
            MessageBox.Show("Data Isian Belum Lengkap", "Validasi Data")
        Else
            sql = ""

            If databaru Then
                sql = "insert into tbltransaksi values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)"
            Else
                sql = "update tbltransaksi set jenis_transaksi = @p2, leasing = @p3, otr=@p7, dp=@p8,besar_pinjaman=@p9,angsuran=@p10,tenor = @p11,keterangan=@p13,status_transaksi=@p14 where no_transaksi=@p1"
            End If

            If eksekusi_query(sql, False) Then
                MessageBox.Show("Data Berhasil Disimpan")
                aktif_komponen(False)
            Else
                MessageBox.Show("Data Gagal Disimpan")
            End If
        End If
    End Sub

    Private Sub btnClearAll_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        txtCustId.Text = ""
        txtNamaCust.Text = ""
        txtNikCust.Text = ""
        txtNomorPolisi.Text = ""
        txtMerk.Text = ""
        txtType.Text = ""
        txtCariCustomer.Text = ""
        txtCariNoPol.Text = ""
        txtNoTransaksi.Text = ""
        cboJenis.SelectedIndex = -1
        cboLeasing.SelectedIndex = -1
        dtpTanggalTransaksi.Refresh()
        txtOtr.Text = ""
        txtDp.Text = ""
        txtBesarPinjaman.Text = ""
        txtAngsuran.Text = ""
        cboTenor.SelectedIndex = -1
        txtKeterangan.Text = ""
        cboStatusTransaksi.SelectedIndex = -1
        txtCariCustomer.Focus()
    End Sub

    Private Sub drgCustomer_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drgCustomer.SelectionChanged
        Dim i As Integer
        If drgCustomer.SelectedRows.Count <> 0 Then
            i = drgCustomer.CurrentRow.Index
            txtCustId.Text = drgCustomer(0, i).Value.ToString()
            txtNamaCust.Text = drgCustomer(1, i).Value.ToString()
            txtNikCust.Text = drgCustomer(4, i).Value.ToString()
            txtCariCustomer.Text = drgCustomer(1, i).Value.ToString()
        End If

    End Sub

    Private Sub drgVehicle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drgVehicle.SelectionChanged
        Dim i As Integer
        If drgVehicle.SelectedRows.Count <> 0 Then
            i = drgVehicle.CurrentRow.Index
            txtNomorPolisi.Text = drgVehicle(0, i).Value.ToString()
            txtMerk.Text = drgVehicle(1, i).Value.ToString()
            txtType.Text = drgVehicle(2, i).Value.ToString()
            txtCariNoPol.Text = drgVehicle(0, i).Value.ToString()
        End If
    End Sub

    Private Sub txtNamaCust2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNamaCust2.TextChanged
        muat_data4()
    End Sub


    Private Sub txtNomorPolisi2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomorPolisi2.TextChanged
        muat_data5()
    End Sub

    Private Sub cboLeasing2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeasing2.SelectedIndexChanged
        muat_data6()
    End Sub

    Private Sub cboStatus2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus2.SelectedIndexChanged
        muat_data7()
    End Sub

    Private Sub dtpTanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTanggal.ValueChanged
        muat_data8()
    End Sub

    Private Sub drgTransaction_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles drgTransaction.CellClick
       
    End Sub

    Private Sub btnShowCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCustomer.Click
        Customer_master.Show()
    End Sub

    Private Sub btnShowVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowVehicle.Click
        Vehicle_master.Show()
    End Sub

    Private Sub cboJenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJenis.SelectedIndexChanged
        If cboJenis.SelectedItem = "REGU" Then
            txtBesarPinjaman.Text = "-"
            txtBesarPinjaman.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim NikPasangan, NamaBPKB, Nama_ibu, TglStnk, Warna, NoBpkb, TglBpkb, AlamatBPKB, PekerjaanBPKB, NikBPKB, NoRangka, NoMesin, Tahun, NamaCustomer, TempatLahirCustomer, TTLCustomer, NamaPasangan, TempatLahirPasangan, Status, TTLPasangan, AlamatKTP, AlamatSurvey, NoHP, Pekerjaan As String
        Dim iRowIndex As Integer

        For i As Integer = 0 To Me.drgCustomer.SelectedCells.Count - 1
            iRowIndex = Me.drgCustomer.SelectedCells.Item(i).RowIndex
            NamaCustomer = drgCustomer.Rows(iRowIndex).Cells(1).Value.ToString()
            TempatLahirCustomer = drgCustomer.Rows(iRowIndex).Cells(2).Value.ToString()
            TTLCustomer = drgCustomer.Rows(iRowIndex).Cells(3).Value.ToString()
            Nama_ibu = drgCustomer.Rows(iRowIndex).Cells(5).Value.ToString()
            Status = drgCustomer.Rows(iRowIndex).Cells(6).Value.ToString()
            NamaPasangan = drgCustomer.Rows(iRowIndex).Cells(7).Value.ToString()
            TempatLahirPasangan = drgCustomer.Rows(iRowIndex).Cells(8).Value.ToString()
            TTLPasangan = drgCustomer.Rows(iRowIndex).Cells(9).Value.ToString()
            NikPasangan = drgCustomer.Rows(iRowIndex).Cells(10).Value.ToString()
            AlamatKTP = drgCustomer.Rows(iRowIndex).Cells(11).Value.ToString()
            AlamatSurvey = drgCustomer.Rows(iRowIndex).Cells(12).Value.ToString()
            NoHP = drgCustomer.Rows(iRowIndex).Cells(13).Value.ToString()
            Pekerjaan = drgCustomer.Rows(iRowIndex).Cells(14).Value.ToString()
        Next

        For b As Integer = b To Me.drgVehicle.SelectedCells.Count - 1
            iRowIndex2 = Me.drgVehicle.SelectedCells.Item(b).RowIndex
            Tahun = drgVehicle.Rows(iRowIndex2).Cells(3).Value.ToString()
            NoRangka = drgVehicle.Rows(iRowIndex2).Cells(5).Value.ToString()
            NoMesin = drgVehicle.Rows(iRowIndex2).Cells(6).Value.ToString()
            NamaBPKB = drgVehicle.Rows(iRowIndex2).Cells(8).Value.ToString()
            AlamatBPKB = drgVehicle.Rows(iRowIndex2).Cells(9).Value.ToString()
            PekerjaanBPKB = drgVehicle.Rows(iRowIndex2).Cells(10).Value.ToString()
            NikBPKB = drgVehicle.Rows(iRowIndex2).Cells(11).Value.ToString()
            NoBpkb = drgVehicle.Rows(iRowIndex2).Cells(7).Value.ToString()
            Warna = drgVehicle.Rows(iRowIndex2).Cells(4).Value.ToString()
            TglStnk = drgVehicle.Rows(iRowIndex2).Cells(13).Value.ToString()
            TglBpkb = drgVehicle.Rows(iRowIndex2).Cells(12).Value.ToString()
        Next


        FormatOrder.txtOrder.Text = "Order Dealer Gaya Motor" + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Biss Unit : " + cboJenis.Text + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Nama Customer : " + NamaCustomer + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "TTL : " + TempatLahirCustomer + ", " + TTLCustomer.Substring(0, 10) + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "NIK : " + txtNikCust.Text + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Status : " + Status + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Nama Ibu Kandung : " + Nama_ibu + Environment.NewLine + Environment.NewLine
        If Status = "KAWIN" Then
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Nama Pasangan : " + NamaPasangan + Environment.NewLine
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "TTL : " + TempatLahirPasangan + ", " + TTLPasangan.Substring(0, 10) + Environment.NewLine
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "NIK : " + NikPasangan + Environment.NewLine + Environment.NewLine

        Else
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Nama Pasangan : -" + Environment.NewLine
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "TTL : -" + Environment.NewLine
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "NIK : -" + Environment.NewLine + Environment.NewLine
        End If
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Alamat KTP : " + AlamatKTP + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Alamat Survey : " + AlamatSurvey + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "No HP : " + NoHP + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Merk/Type : " + txtMerk.Text + " " + txtType.Text + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Nomor Polisi : " + txtNomorPolisi.Text + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Tahun : " + Tahun + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Warna : " + Warna + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Tgl STNK : " + TglStnk + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "NR : " + NoRangka + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "NM : " + NoMesin + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Nama di BPKB : " + NamaBPKB + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Alamat BPKB : " + AlamatBPKB + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Pekerjaan BPKB : " + PekerjaanBPKB + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "NIK BPKB : " + NikBPKB + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "No BPKB : " + NoBpkb + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Tgl BPKB : " + TglBpkb + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "OTR : " + txtOtr.Text + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "DP : " + txtDp.Text + Environment.NewLine
        If cboJenis.Text = "REFI" Then
            FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Besar Pinjaman : " + txtBesarPinjaman.Text + Environment.NewLine
        Else

        End If
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Ang : " + txtAngsuran.Text + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "TOP : " + cboTenor.Text + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Pekerjaan : " + Pekerjaan + Environment.NewLine + Environment.NewLine
        FormatOrder.txtOrder.Text = FormatOrder.txtOrder.Text + "Ket. : " + txtKeterangan.Text + Environment.NewLine

        FormatOrder.Show()
    End Sub

    Private Sub txtBesarPinjaman_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBesarPinjaman.TextChanged
        If cboJenis.Text = "REFI" Then
            txtDp.Text = Val(txtOtr.Text) - Val(txtBesarPinjaman.Text)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If cboCetak.Text = "ORDER" Then
            Form1.txtNoTransaksi1.Text = txtNoTransaksi.Text
            Form1.Show()
        ElseIf cboCetak.Text = "KWITANSI DP" Then
            Form2.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form2.Show()
        ElseIf cboCetak.Text = "KWITANSI PELUNASAN" Then
            Form3.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form3.Show()
        ElseIf cboCetak.Text = "KWITANSI SCHEME (REFI)" Then
            Form4.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form4.Show()
        ElseIf cboCetak.Text = "KWITANSI SCHEME (REGU)" Then
            Form5.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form5.Show()
        ElseIf cboCetak.Text = "SURAT JALAN" Then
            Form6.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form6.Show()
        ElseIf cboCetak.Text = "BAST" Then
            Form7.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form7.Show()
        ElseIf cboCetak.Text = "KWITANSI TERIMA DANA DAN PENAGIHAN" Then
            Form8.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form8.Show()
        ElseIf cboCetak.Text = "SK01KA" Then
            Form9.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form9.Show()
        ElseIf cboCetak.Text = "SK02AK" Then
            Form10.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form10.Show()
        ElseIf cboCetak.Text = "STD" Then
            Form11.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form11.Show()
        ElseIf cboCetak.Text = "STD UTK NAMA PASANGAN" Then
            Form12.txtNoTransaksi12.Text = txtNoTransaksi.Text
            Form12.Show()
        End If
    End Sub

    Private Sub drgTransaction_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drgTransaction.SelectionChanged

        Dim i As Integer
        i = drgTransaction.CurrentRow.Index
        txtCariCustomer.Text = drgTransaction(4, i).Value.ToString()
        txtCariNoPol.Text = drgTransaction(5, i).Value.ToString()
        txtNoTransaksi.Text = drgTransaction(0, i).Value.ToString()
        txtOtr.Text = drgTransaction(6, i).Value.ToString()
        txtDp.Text = drgTransaction(7, i).Value.ToString()
        txtBesarPinjaman.Text = drgTransaction(8, i).Value.ToString()
        txtAngsuran.Text = drgTransaction(9, i).Value.ToString()
        cboTenor.Text = drgTransaction(10, i).Value.ToString()
        cboJenis.Text = drgTransaction(1, i).Value.ToString()
        cboLeasing.Text = drgTransaction(2, i).Value.ToString()
        dtpTanggalTransaksi.Value = drgTransaction(11, i).Value.ToString()
        txtKeterangan.Text = drgTransaction(12, i).Value.ToString()
        cboStatusTransaksi.Text = drgTransaction(13, i).Value.ToString()

    End Sub

End Class