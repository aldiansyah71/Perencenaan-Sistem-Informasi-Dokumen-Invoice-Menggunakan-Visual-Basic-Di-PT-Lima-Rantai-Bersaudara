Imports MySql.Data.MySqlClient
Public Class Form2
    Dim kodesd
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'StartPosition = FormStartPosition.CenterScreen
        'totalorder()
        'totalorder()
        validasi()




        Call koneksi()
        Me.CenterToScreen()
        nomor()
        tampil_data()
        munculdatatr()
        nomorresi()
        tampil_datastatus()
        pnl_utama.Show()
        totalorder()
        proses()
        totaldatatransaksi()
        'otomatis_resi()

    End Sub

    Private Sub btn_dashboard_Click(sender As Object, e As EventArgs) Handles btn_dashboard.Click
        totalorder()
        proses()
        totaldatatransaksi()
        Label1.Visible = True
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label36.Visible = False


        pnl_utama.Visible = True
            pnl_mastercs.Visible = False
            pnl_transaksi.Visible = False
            pnl_status.Visible = False
            pnl_laporan.Visible = False


    End Sub

    Private Sub btn_master_Click(sender As Object, e As EventArgs) Handles btn_master.Click
        Label1.Visible = False
        Label2.Visible = True
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label36.Visible = False


        pnl_utama.Visible = False
        pnl_mastercs.Visible = True
        pnl_transaksi.Visible = False
        pnl_status.Visible = False
        pnl_laporan.Visible = False



    End Sub

    Private Sub btn_transaksi_Click(sender As Object, e As EventArgs) Handles btn_transaksi.Click
        munculdatatr()

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = True
        Label4.Visible = False
        Label5.Visible = False
        Label36.Visible = False

        pnl_utama.Visible = False
        pnl_mastercs.Visible = False
        pnl_transaksi.Visible = True
        pnl_status.Visible = False
        pnl_laporan.Visible = False





    End Sub

    Private Sub btn_status_Click(sender As Object, e As EventArgs) Handles btn_status.Click
        kunci()
        tampil_datastatus()

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label36.Visible = True

        pnl_utama.Visible = False
        pnl_mastercs.Visible = False
        pnl_transaksi.Visible = False
        pnl_status.Visible = True
        pnl_laporan.Visible = False

    End Sub

    Private Sub btn_laporan_Click(sender As Object, e As EventArgs) Handles btn_laporan.Click
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = True
        Label5.Visible = False
        Label36.Visible = False

        pnl_utama.Visible = False
        pnl_mastercs.Visible = False
        pnl_transaksi.Visible = False
        pnl_status.Visible = False
        pnl_laporan.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = True
        Me.Close()
        Form1.Show()


        Form1.TextBox1.Text = ""
        Form1.TextBox2.Text = ""
        Form1.TextBox1.Select()


    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_simpancs.Click
        Call koneksi()

        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Then
            MsgBox(" Silahkan Isi Data dengan lengkap")
        Else

            Dim simpan As String
            MsgBox("Data Berhasil Di Simpan")
            simpan = "insert into master_pelanggan (kode,nama_pelanggan,alamat,nomer_hp) values('" &
           Me.TextBox1.Text & "','" & Me.TextBox2.Text & "','" & Me.TextBox3.Text & "','" & Me.TextBox4.Text & "')"
            cmd = New MySqlCommand(simpan, con) ' untuk menghubungkan ke database dan table lalu simpan
            cmd.ExecuteNonQuery() ' mengeksekusi datanya

        End If
        tampil_data()
        nomor()
    End Sub




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_editcs.Click
        If Me.TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di update")
        Else

            ' ------- Coding update data --------
            MsgBox(" Data Di Update")
            Dim edit As String
            edit = "update master_pelanggan set kode ='" _
            & Me.TextBox1.Text & "' , nama_pelanggan = '" _
            & Me.TextBox2.Text & "',alamat ='" _
            & Me.TextBox3.Text & "',nomer_hp ='" _
            & Me.TextBox4.Text & "' where kode = '" & Me.TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con) ' untuk menghubungkan ke database dan table lalu Update
            cmd.ExecuteNonQuery() ' mengeksekusi datanya
            tampil_data()
        End If
    End Sub



    Private Sub btn_hapuscs_Click(sender As Object, e As EventArgs) Handles btn_hapuscs.Click
        If Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di hapus")
        Else
            ' ------- Coding update data --------
            If MessageBox.Show(" Apakah Anda Yakin Menghapusnya ???", "",
           MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String
                hapus = "delete from master_pelanggan where kode = '" & Me.TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                bersih()
                nomor()
            Else
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        On Error Resume Next
        kodesd = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = kodesd
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value

        btn_simpancs.Enabled = False
        btn_editcs.Enabled = True
        btn_hapuscs.Enabled = True


    End Sub

    Private Sub btn_clearcs_Click(sender As Object, e As EventArgs) Handles btn_clearcs.Click
        bersih()
    End Sub




    Sub bersih()

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        '--------- Untuk mematikan tombol
        btn_simpancs.Enabled = True
        btn_editcs.Enabled = True
        btn_hapuscs.Enabled = True
        tampil_data()
        nomor()

    End Sub

    Sub nomor()
        Call koneksi()
        Dim DR As DataRow
        Dim s As String
        'mengambil kode dari field ID, kemudian dicari nilai yg paling besar (max)
        'kemudian hasilnya d tampung d field buatan dgn nama Nomor
        DR = SQLTable("select max(right(kode,1)) as nomor from master_pelanggan").Rows(0)
        'jika berisi null atau tdk ditemukan
        If DR.IsNull("Nomor") Then
            s = "CS-1" 'member nilai awal
        Else
            s = "CS-" & Format(DR("Nomor") + 1, "0")
        End If
        TextBox1.Text = s
        TextBox1.Enabled = False
    End Sub

    Sub tampil_data()
        Call koneksi()
        '------- Untuk menampilkan data di datagrid -----------
        da = New MySqlDataAdapter("select * from master_pelanggan order by kode", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "master_pelanggan")
        Me.DataGridView1.DataSource = (ds.Tables("master_pelanggan"))
        '-------------- diatas codingnya ---------------
        nomor()
    End Sub

    Private Sub pnl_transaksi_Paint(sender As Object, e As PaintEventArgs) Handles pnl_transaksi.Paint

    End Sub

    Function munculdatatr()
        Call koneksi()
        customer.Items.Clear()
        cmd = New MySqlCommand("Select * From master_pelanggan", con)
        rd = cmd.ExecuteReader
        Do While rd.Read
            customer.Items.Add(rd.Item(1))
        Loop

    End Function

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles customer.SelectedIndexChanged
        Call koneksi()
        cmd = New MySqlCommand("Select * from master_pelanggan where nama_pelanggan='" & customer.Text & "'", con)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            kode.Text = rd!kode
            alamat.Text = rd!alamat
            nohp.Text = rd!nomer_hp

        End If
    End Sub


    Sub otomatis_resi()
        Call koneksi()
        cmd = New MySqlCommand("select * from transaksi where no_resi in (select max(no_resi) from transaksi)", con)
        Dim kodeurut As String
        Dim hitung As Long
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            kodeurut = "T" + Format(Now, "yyMMdd") + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(rd.GetString(0), 9) + 1
            kodeurut = "T" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        noresi.Text = kodeurut
    End Sub

    Sub nomorresi()
        Call koneksi()
        Dim DR As DataRow
        Dim s As String
        'mengambil kode dari field ID, kemudian dicari nilai yg paling besar (max)
        'kemudian hasilnya d tampung d field buatan dgn nama Nomor
        DR = SQLTable("select max(right(no_resi,1)) as nomor from transaksi").Rows(0)
        'jika berisi null atau tdk ditemukan
        If DR.IsNull("Nomor") Then
            s = "TRS-1" 'member nilai awal
        Else
            s = "TRS-" & Format(DR("Nomor") + 1, "0")
        End If
        noresi.Text = s
        noresi.Enabled = False
    End Sub

    Private Sub btn_proses_Click(sender As Object, e As EventArgs) Handles btn_proses.Click
        Call koneksi()


        If Me.noresi.Text = "" Or Me.customer.Text = "" Or Me.pembayaran.Text = "" Or Me.status.Text = "" Then
            MsgBox(" Silahkan Isi Data dengan lengkap")
        Else
            Dim tglsaya As String
            Dim simpan As String

            tglsaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            MsgBox("Data Berhasil Di Simpan")


            For Baris As Integer = 0 To DataGridView2.Rows.Count - 2
                Dim SimpanDetail As String = "insert into transaksi values('" & tglsaya & "','" & Me.noresi.Text & "','" &
                    Me.admin.Text & "','" & customer.Text & "','" & Me.kode.Text & "','" & Me.alamat.Text & "','" & Me.nohp.Text & "','" &
                    DataGridView2.Rows(Baris).Cells(0).Value & "','" & DataGridView2.Rows(Baris).Cells(1).Value & "','" &
                    DataGridView2.Rows(Baris).Cells(2).Value & "','" & DataGridView2.Rows(Baris).Cells(3).Value & "','" & DataGridView2.Rows(Baris).Cells(4).Value & "','" &
                    Me.gtotal.Text & "','" & Me.pembayaran.Text & "','" & Me.status.Text & "')"
                cmd = New MySqlCommand(SimpanDetail, con)
                rd.Close()
                cmd.ExecuteNonQuery()
            Next
            If MessageBox.Show("Apakah ingin cetak nota...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                AxCrystalReport1.SelectionFormula = "totext({transaksi.no_resi})='" & noresi.Text & "'"
                AxCrystalReport1.ReportFileName = "Transaksi.rpt"
                AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
                AxCrystalReport1.RetrieveDataFiles()
                AxCrystalReport1.Action = 1

            Else

                MsgBox("Transaksi Telah Berhasil Disimpan!")
            End If


        End If


    End Sub

    Private Sub btn_deletedata_Click(sender As Object, e As EventArgs) Handles btn_deletedata.Click
        hapusdatagrid()
        jumlahbayar()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        cleardata()
        nomorresi()
    End Sub

    Sub tambahdatagrid()
        DataGridView2.Rows.Add(1)
        DataGridView2.Rows(DataGridView2.RowCount - 2).Cells(0).Value = pelayanan.Text
        DataGridView2.Rows(DataGridView2.RowCount - 2).Cells(1).Value = type.Text
        DataGridView2.Rows(DataGridView2.RowCount - 2).Cells(2).Value = jumlah.Text
        DataGridView2.Rows(DataGridView2.RowCount - 2).Cells(3).Value = HSatuan.Text
        DataGridView2.Rows(DataGridView2.RowCount - 2).Cells(4).Value = Val(jumlah.Text) * Val(HSatuan.Text)
    End Sub



    Private Sub HSatuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles HSatuan.KeyPress
        If e.KeyChar = Chr(13) Then
            tambahdatagrid()
            jumlahbayar()
            bersih_transaksi()
        End If
    End Sub

    Sub jumlahbayar()
        Dim A As Integer
        For line As Integer = 0 To DataGridView2.RowCount - 1
            A = A + DataGridView2.Rows(line).Cells(4).Value
            DataGridView2.Update()
        Next
        gtotal.Text = Val(A)

    End Sub

    Sub bersih_transaksi()
        pelayanan.Text = ""
        type.Text = ""
        jumlah.Text = ""
        HSatuan.Text = ""
    End Sub

    Sub hapusdatagrid()
        Dim rowindex As Integer
        rowindex = DataGridView2.CurrentCell.RowIndex
        DataGridView2.Rows.RemoveAt(rowindex)
    End Sub

    Sub cleardata()
        pelayanan.Text = ""
        type.Text = ""
        jumlah.Text = ""
        HSatuan.Text = ""
        customer.Text = ""
        kode.Text = ""
        alamat.Text = ""
        nohp.Text = ""
        gtotal.Text = ""
        pembayaran.Text = ""
        status.Text = ""
        DataGridView2.Rows.Clear()
    End Sub

    Sub tampil_datastatus()
        Call koneksi()
        '------- Untuk menampilkan data di datagrid -----------
        da = New MySqlDataAdapter("select * from transaksi order by no_resi", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "transaksi")
        Me.DataGridView3.DataSource = (ds.Tables("transaksi"))
        '-------------- diatas codingnya ---------------

    End Sub



    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        On Error Resume Next
        kodesd = DataGridView3.Rows(e.RowIndex).Cells(3).Value
        so_customer.Text = kodesd
        so_kode.Text = DataGridView3.Rows(e.RowIndex).Cells(4).Value
        so_alamat.Text = DataGridView3.Rows(e.RowIndex).Cells(5).Value
        so_noresi.Text = DataGridView3.Rows(e.RowIndex).Cells(1).Value
        so_admin.Text = DataGridView3.Rows(e.RowIndex).Cells(2).Value
        so_status.Text = DataGridView3.Rows(e.RowIndex).Cells(14).Value

    End Sub

    Sub kunci()
        so_customer.Enabled = False
        so_kode.Enabled = False
        so_alamat.Enabled = False
        so_noresi.Enabled = False
        so_admin.Enabled = False

    End Sub

    Private Sub btn_simpanSO_Click(sender As Object, e As EventArgs) Handles btn_simpanSO.Click
        If Me.so_customer.Text = "" Or so_noresi.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di update")
        Else

            ' ------- Coding update data --------
            MsgBox(" Data Di Update")
            Dim edit As String
            edit = "update transaksi set no_resi ='" _
            & Me.so_noresi.Text & "' , status = '" _
            & Me.so_status.Text & "' where no_resi = '" & Me.so_noresi.Text & "'"
            cmd = New MySqlCommand(edit, con) ' untuk menghubungkan ke database dan table lalu Update
            cmd.ExecuteNonQuery() ' mengeksekusi datanya
            tampil_datastatus()
            refresh_so()
        End If
    End Sub

    Sub refresh_so()
        so_customer.Text = ""
        so_kode.Text = ""
        so_alamat.Text = ""
        so_noresi.Text = ""
        so_admin.Text = ""
        so_status.Text = ""
    End Sub

    Private Sub btn_refreshSO_Click(sender As Object, e As EventArgs) Handles btn_refreshSO.Click
        refresh_so()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        '----------- menyaring di datagrid dengan nama---------
        da = New MySqlDataAdapter("select * from transaksi where no_resi like '%" _
        & Me.TextBox5.Text & "%'", con)
        ds = New DataSet
        ' ds.Clear()
        da.Fill(ds, "transaksi")
        DataGridView3.DataSource = (ds.Tables("transaksi"))
    End Sub

    Sub totalorder()
        Dim value As String
        Call koneksi()

        Dim command As New MySqlCommand("SELECT COUNT(*) FROM transaksi WHERE status = 'selesai'", con)
        command.Parameters.AddWithValue("status", value)
        Dim count As Integer = CType(command.ExecuteScalar(), Integer)
        Label9.Text = count.ToString()

    End Sub

    Sub proses()
        Dim value As String
        Call koneksi()

        Dim command As New MySqlCommand("SELECT COUNT(*) FROM transaksi WHERE status = 'di proses'", con)
        command.Parameters.AddWithValue("status", value)
        Dim count As Integer = CType(command.ExecuteScalar(), Integer)
        Label34.Text = count.ToString()

    End Sub

    Sub totaldatatransaksi()
        Dim value As String
        Call koneksi()

        Dim command As New MySqlCommand("SELECT COUNT(DISTINCT no_resi) FROM transaksi", con)
        command.Parameters.AddWithValue("no_resi", value)
        Dim count As Integer = CType(command.ExecuteScalar(), Integer)
        Label20.Text = count.ToString()

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        AxCrystalReport4.SelectionFormula = "{transaksi.tanggal} in date ('" & DTP1.Value & "') to date ('" & DTP2.Value & "')"
        AxCrystalReport4.ReportFileName = "laporanpenjualan.rpt"
        AxCrystalReport4.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport4.RetrieveDataFiles()
        AxCrystalReport4.Action = 1
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        AxCrystalReport3.ReportFileName = "Customer.rpt"
        AxCrystalReport3.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport3.RetrieveDataFiles()
        AxCrystalReport3.Action = 1
    End Sub

    Sub validasi()
        If userr.Text = "admin" Then
            btn_dashboard.Enabled = True
            btn_master.Enabled = True
            btn_transaksi.Enabled = True
            btn_status.Enabled = True
            btn_laporan.Enabled = True
        Else
            btn_dashboard.Enabled = True
            btn_master.Enabled = False
            btn_transaksi.Enabled = False
            btn_status.Enabled = False
            btn_laporan.Enabled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        '----------- menyaring di datagrid dengan nama---------

        Call koneksi()
        da = New MySqlDataAdapter("select * from master_pelanggan where nama_pelanggan like '%" _
        & Me.TextBox6.Text & "%'", con)
        ds = New DataSet
        ' ds.Clear()
        da.Fill(ds, "master_pelanggan")
        DataGridView1.DataSource = (ds.Tables("master_pelanggan"))
    End Sub

    Private Sub pnl_mastercs_Paint(sender As Object, e As PaintEventArgs) Handles pnl_mastercs.Paint

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class