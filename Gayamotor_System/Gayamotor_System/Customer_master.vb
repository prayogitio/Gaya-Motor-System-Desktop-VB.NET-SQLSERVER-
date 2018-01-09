Imports System.Data.SqlClient
Public Class Customer_master
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

        drgCustomer.Enabled = Not x

        txtCustId.Enabled = False
        txtNamaCust.Enabled = x
        txtTempatLahir.Enabled = x
        dtpTtl.Enabled = x
        txtNik.Enabled = x
        cboStatus.Enabled = x
        txtNamaPasangan.Enabled = x
        txtNamaIbu.Enabled = x
        txtTempatLahirPasangan.Enabled = x
        dtpTtlPasangan.Enabled = x
        txtNikPasangan.Enabled = x
        txtAlamatKtp.Enabled = x
        txtAlamatSurvey.Enabled = x
        txtNoHp.Enabled = x
        txtPekerjaan.Enabled = x


        If x = False Then muat_data()
    End Sub

    Sub data_baru()
        Dim x As Integer
        x = drgCustomer.RowCount
        txtCustId.Text = x
        txtNamaCust.Text = ""
        txtTempatLahir.Text = ""
        dtpTtl.Refresh()
        txtNik.Text = ""
        txtNamaIbu.Text = ""
        txtNamaPasangan.Text = ""
        txtTempatLahirPasangan.Text = ""
        dtpTtlPasangan.Refresh()
        txtNikPasangan.Text = ""
        cboStatus.SelectedIndex = -1
        txtAlamatKtp.Text = ""
        txtAlamatSurvey.Text = ""
        txtNoHp.Text = ""
        txtPekerjaan.Text = ""
        txtNamaCust.Focus()
        dtpTtl.Value = Date.Now
        dtpTtlPasangan.Value = Date.Now
    End Sub

    Sub muat_data()
        sql = "SELECT * FROM tblcustomer where nama like '%" + txtPencarian.Text + "%' or customer_id = '" + txtPencarian.Text + "'"
        Dim adp As New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        adp.Fill(dt)
        drgCustomer.DataSource = dt
    End Sub

    Function validasi_data() As Boolean
        Dim hasil As Boolean = True

        If txtCustId.Text = "" Then hasil = False
        If txtNamaCust.Text = "" Then hasil = False
        If txtTempatLahir.Text = "" Then hasil = False
        If txtNik.Text = "" Then hasil = False
        If txtNamaIbu.Text = "" Then hasil = False
        If txtNamaPasangan.Text = "" Then hasil = False
        If txtTempatLahirPasangan.Text = "" Then hasil = False
        If cboStatus.Text = "" Then hasil = False
        If txtNikPasangan.Text = "" Then hasil = False
        If txtAlamatKtp.Text = "" Then hasil = False
        If txtAlamatSurvey.Text = "" Then hasil = False
        If txtNoHp.Text = "" Then hasil = False
        If txtPekerjaan.Text = "" Then hasil = False

        Return hasil
    End Function

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        aktif_komponen(False)
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        If drgCustomer.CurrentRow.Index = -1 Then
            MessageBox.Show("Silakan Pilih Dulu!", "Validasi")
        Else
            Dim kode As String = drgCustomer(0, drgCustomer.CurrentRow.Index).Value.ToString()
            Dim nama As String = drgCustomer(1, drgCustomer.CurrentRow.Index).Value.ToString()

            Dim pesan As String
            pesan = "Yakin Hapus : " + kode + " - " + nama + " ? "

            Dim result As DialogResult
            result = MessageBox.Show(pesan, "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = Windows.Forms.DialogResult.Yes Then
                sql = "Delete from tblcustomer where customer_id = @p1"
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
                    .Parameters.AddWithValue("p1", txtCustId.Text)
                    .Parameters.AddWithValue("p2", txtNamaCust.Text)
                    .Parameters.AddWithValue("p3", txtTempatLahir.Text)
                    .Parameters.AddWithValue("p4", dtpTtl.Value)
                    .Parameters.AddWithValue("p5", txtNik.Text)
                    .Parameters.AddWithValue("p6", cboStatus.Text)
                    .Parameters.AddWithValue("p7", txtNamaPasangan.Text)
                    .Parameters.AddWithValue("p8", txtTempatLahirPasangan.Text)
                    .Parameters.AddWithValue("p9", dtpTtlPasangan.Value)
                    .Parameters.AddWithValue("p10", txtNikPasangan.Text)
                    .Parameters.AddWithValue("p11", txtAlamatKtp.Text)
                    .Parameters.AddWithValue("p12", txtAlamatSurvey.Text)
                    .Parameters.AddWithValue("p13", txtNoHp.Text)
                    .Parameters.AddWithValue("p14", txtPekerjaan.Text)
                    .Parameters.AddWithValue("p15", txtNamaIbu.Text)
                Else
                    .Parameters.AddWithValue("p1", txtCustId.Text)
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
        txtPencarian.Text = Transaction_master2.txtCustId.Text
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
        txtCustId.Enabled = False
        txtNamaCust.Focus()
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click

        If validasi_data() = False Then
            MessageBox.Show("Data Isian Belum Lengkap", "Validasi Data")
        Else
            sql = ""

            If databaru Then
                sql = "insert into tblcustomer values (@p1,@p2,@p3,@p4,@p5,@p15,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)"
            Else
                sql = "update tblcustomer set nama = @p2,tempat_lahir = @p3, nama_ibu=@p15, tgl_lahir = @p4, nik =@p5,status=@p6,nama_pasangan=@p7, tempat_lahir_pasangan=@p8, tgl_lahir_pasangan=@p9,nik_pasangan=@p10,alamat_ktp=@p11,alamat_survey = @p12,no_hp=@p13,pekerjaan=@p14 where customer_id=@p1"
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

    Private Sub chkAlamat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlamat.CheckedChanged
        If chkAlamat.Checked Then
            txtAlamatSurvey.Text = txtAlamatKtp.Text
            txtNoHp.Focus()
        Else
            txtAlamatSurvey.Text = ""
            txtAlamatSurvey.Focus()
        End If
    End Sub

    Private Sub drgCustomer_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drgCustomer.SelectionChanged
        Dim i As Integer

        i = drgCustomer.CurrentRow.Index
        txtCustId.Text = drgCustomer(0, i).Value.ToString()
        txtNamaCust.Text = drgCustomer(1, i).Value.ToString()
        txtTempatLahir.Text = drgCustomer(2, i).Value.ToString()
        dtpTtl.Text = drgCustomer(3, i).Value.ToString()
        txtNik.Text = drgCustomer(4, i).Value.ToString()
        txtNamaIbu.Text = drgCustomer(5, i).Value.ToString()
        cboStatus.Text = drgCustomer(6, i).Value.ToString()
        txtNamaPasangan.Text = drgCustomer(7, i).Value.ToString()
        txtTempatLahirPasangan.Text = drgCustomer(8, i).Value.ToString()
        dtpTtlPasangan.Text = drgCustomer(9, i).Value.ToString()
        txtNikPasangan.Text = drgCustomer(10, i).Value.ToString()
        txtAlamatKtp.Text = drgCustomer(11, i).Value.ToString()
        txtAlamatSurvey.Text = drgCustomer(12, i).Value.ToString()
        txtNoHp.Text = drgCustomer(13, i).Value.ToString()
        txtPekerjaan.Text = drgCustomer(14, i).Value.ToString()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If cboStatus.SelectedItem = "KAWIN" Then
            txtNamaPasangan.Enabled = True
            txtTempatLahirPasangan.Enabled = True
            txtNikPasangan.Enabled = True
        Else
            txtNamaPasangan.Enabled = False
            txtTempatLahirPasangan.Enabled = False
            txtNikPasangan.Enabled = False
            txtNamaPasangan.Text = "-"
            txtTempatLahirPasangan.Text = "-"
            txtNikPasangan.Text = "-"
            txtAlamatKtp.Focus()
        End If
    End Sub

End Class