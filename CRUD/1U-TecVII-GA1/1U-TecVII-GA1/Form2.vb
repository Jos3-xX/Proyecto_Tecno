Imports System.Data.SqlClient
Public Class Form2
    Dim con As New SqlConnection(My.Settings.Conexión)
    Dim mensaje, sentencia As String
    Sub EjecutarSql(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New SqlCommand(sql, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub
    Private Sub btn_Insertar_Click(sender As Object, e As EventArgs) Handles btn_Insertar.Click
        sentencia = "Insert into usuario values('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')"
        mensaje = "Datos insertados correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("Select * from Usuario", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_Cargar_Click(sender As Object, e As EventArgs) Handles btn_Cargar.Click
        Try
            Dim da As New SqlDataAdapter("Select *from usuario", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_borrar_Click(sender As Object, e As EventArgs) Handles btn_borrar.Click
        sentencia = "Delete Usuario where id = '" + TextBox1.Text + "'"
        mensaje = "Datos eliminados correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("select *from Usuario", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class