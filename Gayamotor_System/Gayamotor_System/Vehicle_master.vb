Imports System.Data.SqlClient
Public Class Vehicle_master
    Dim con As New SqlConnection("Data Source=(local)\SQLEXPRESS3;" +
                             "Initial Catalog=gayamotor;" +
                             "Integrated Security=True;")
    Dim sql As String
    Dim cmd As SqlCommand
    Dim databaru As Boolean

    Sub aktif_komponen(ByVal x As Boolean)
        btnTambah.Enabled = Not x
        btnEdit.Enabled = Not x
        btnSimpan.Enabled = x
        btnBatal.Enabled = x
        btnHapus.Enabled = Not x
        btnKeluar.Enabled = Not x

        drgVehicle.Enabled = Not x


        txtNomorPolisi.Enabled = x
        cboMerk.Enabled = x
        dtpBPKB.Enabled = x
        dtpSTNK.Enabled = x
        txtType.Enabled = x
        txtTahunPerakitan.Enabled = x
        txtWarna.Enabled = x
        txtNoRangka.Enabled = x
        txtNoMesin.Enabled = x
        txtNamaBpkb.Enabled = x
        txtAlamatBpkb.Enabled = x
        txtNikBpkb.Enabled = x
        txtPekerjaanBpkb.Enabled = x
        txtNoBpkb.Enabled = x


        If x = False Then muat_data()
    End Sub

    Sub data_baru()
        txtNomorPolisi.Text = ""
        cboMerk.SelectedIndex = -1
        txtType.Text = ""
        txtTahunPerakitan.Text = ""
        txtWarna.Text = ""
        txtNoRangka.Text = ""
        txtNoMesin.Text = ""
        txtNamaBpkb.Text = ""
        dtpBPKB.Refresh()
        dtpSTNK.Refresh()
        txtPekerjaanBpkb.Text = ""
        txtNoBpkb.Text = ""
        txtAlamatBpkb.Text = ""
        txtNikBpkb.Text = ""
        txtNomorPolisi.Focus()
    End Sub

    Sub muat_data()
        sql = "SELECT * FROM tblkendaraan where nomor_polisi like '%" + txtPencarian.Text + "%'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgVehicle.DataSource = dt
    End Sub

    Function validasi_data() As Boolean
        Dim hasil As Boolean = True

        If txtNomorPolisi.Text = "" Then hasil = False
        If cboMerk.Text = "" Then hasil = False
        If txtType.Text = "" Then hasil = False
        If txtTahunPerakitan.Text = "" Then hasil = False
        If txtWarna.Text = "" Then hasil = False
        If txtNoRangka.Text = "" Then hasil = False
        If txtNoMesin.Text = "" Then hasil = False
        If txtNoBpkb.Text = "" Then hasil = False
        If txtNamaBpkb.Text = "" Then hasil = False
        If txtPekerjaanBpkb.Text = "" Then hasil = False
        If txtAlamatBpkb.Text = "" Then hasil = False
        If txtNikBpkb.Text = "" Then hasil = False

        Return hasil
    End Function

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        aktif_komponen(False)
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        If drgVehicle.CurrentRow.Index = -1 Then
            MessageBox.Show("Silakan Pilih Dulu!", "Validasi")
        Else
            Dim kode As String = drgVehicle(0, drgVehicle.CurrentRow.Index).Value.ToString()
            Dim nama As String = drgVehicle(7, drgVehicle.CurrentRow.Index).Value.ToString()

            Dim pesan As String
            pesan = "Yakin Hapus : " + kode + " - " + nama + " ? "

            Dim result As DialogResult
            result = MessageBox.Show(pesan, "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = Windows.Forms.DialogResult.Yes Then
                sql = "Delete from tblkendaraan where nomor_polisi = @p1"
                If eksekusi_query(sql, True) Then
                    MessageBox.Show("Data berhasil dihapus")
                    aktif_komponen(False)
                Else
                    MessageBox.Show("Data gagal dihapus")
                End If
            End If
        End If
    End Sub

    Function eksekusi_query(ByVal sql As String, ByVal hapus As Boolean) As Boolean
        Dim hasil As Boolean

        Try
            con.Open()
            cmd = New SqlCommand
            With cmd
                .Connection = con
                .CommandText = sql

                If hapus = False Then
                    .Parameters.AddWithValue("p1", txtNomorPolisi.Text)
                    .Parameters.AddWithValue("p2", cboMerk.Text)
                    .Parameters.AddWithValue("p3", txtType.Text)
                    .Parameters.AddWithValue("p4", txtTahunPerakitan.Text)
                    .Parameters.AddWithValue("p5", txtWarna.Text)
                    .Parameters.AddWithValue("p6", txtNoRangka.Text)
                    .Parameters.AddWithValue("p7", txtNoMesin.Text)
                    .Parameters.AddWithValue("p8", txtNoBpkb.Text)
                    .Parameters.AddWithValue("p9", txtNamaBpkb.Text)
                    .Parameters.AddWithValue("p10", txtPekerjaanBpkb.Text)
                    .Parameters.AddWithValue("p11", txtAlamatBpkb.Text)
                    .Parameters.AddWithValue("p12", txtNikBpkb.Text)
                    .Parameters.AddWithValue("p13", dtpBPKB.Value)
                    .Parameters.AddWithValue("p14", dtpSTNK.Value)
                Else
                    .Parameters.AddWithValue("p1", txtNomorPolisi.Text)
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

    Private Sub Customer_master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aktif_komponen(False)
        txtPencarian.Text = Transaction_master2.txtCariNoPol.Text
        If txtPencarian.Text.Trim <> "" Then
            TabPage2.Show()
        End If
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        databaru = True
        aktif_komponen(True)
        data_baru()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        databaru = False
        aktif_komponen(True)
        txtNomorPolisi.Enabled = False
        cboMerk.Focus()
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click

        If validasi_data() = False Then
            MessageBox.Show("Data Isian Belum Lengkap", "Validasi Data")
        Else
            sql = ""

            If databaru Then
                sql = "insert into tblkendaraan values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)"
            Else
                sql = "update tblkendaraan set merk = @p2, type = @p3, tgl_bpkb=@p13,tgl_stnk=@p14,tahun_perakitan = @p4, warna =@p5,no_rangka=@p6, no_mesin=@p7, no_bpkb=@p8,nama_bpkb=@p9,pekerjaan_bpkb=@p10,alamat_bpkb = @p11,nik_bpkb=@p12 where nomor_polisi=@p1"
            End If

            If eksekusi_query(sql, False) Then
                MessageBox.Show("Data Berhasil Disimpan")
                aktif_komponen(False)
            Else
                MessageBox.Show("Data Gagal Disimpan")
            End If
        End If
    End Sub

    Private Sub txtPencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPencarian.TextChanged
        muat_data()
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub drgVehicle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drgVehicle.SelectionChanged
        Dim i As Integer
            i = drgVehicle.CurrentRow.Index
            txtNomorPolisi.Text = drgVehicle(0, i).Value.ToString()
            cboMerk.Text = drgVehicle(1, i).Value.ToString()
            txtType.Text = drgVehicle(2, i).Value.ToString()
            txtTahunPerakitan.Text = drgVehicle(3, i).Value.ToString()
            txtWarna.Text = drgVehicle(4, i).Value.ToString()
            txtNoRangka.Text = drgVehicle(5, i).Value.ToString()
            txtNoMesin.Text = drgVehicle(6, i).Value.ToString()
            txtNoBpkb.Text = drgVehicle(7, i).Value.ToString()
            txtNamaBpkb.Text = drgVehicle(8, i).Value.ToString()
            txtPekerjaanBpkb.Text = drgVehicle(9, i).Value.ToString()
            txtAlamatBpkb.Text = drgVehicle(10, i).Value.ToString()
        txtNikBpkb.Text = drgVehicle(11, i).Value.ToString()
        dtpBPKB.Text = drgVehicle(12, i).Value.ToString()
        dtpSTNK.Text = drgVehicle(13, i).Value.ToString()
    End Sub

End Class