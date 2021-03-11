Imports System
Module Library
    Sub Main()
        Dim stock_De_Ropas(5, 2) As UShort
        Dim identificador As SByte
        Dim tama�o As String = ""
        Dim ingreso_egreso As String = ""
        Dim cantidad_ropas As Integer
        Do
            MostrarRopas()
            IngresoIdentificador(identificador)
            If identificador = 0 Then
                Exit Do
            End If
            MuestroTama�osDeRopa()
            IngresoTama�osDeRopa(tama�o)
            IngresoEgreso(ingreso_egreso)
            IngresoCantidadDeRopas(stock_De_Ropas, identificador, tama�o, ingreso_egreso, cantidad_ropas)
            ActualizarStock(stock_De_Ropas, identificador, tama�o, ingreso_egreso, cantidad_ropas)
            MostrarStock(stock_De_Ropas)
        Loop While identificador <> 0
    End Sub
    Sub MostrarRopas()
        Dim contador As Byte = 0
        For Each s In GetRopas()
            contador += 1
            Console.WriteLine(contador & " - " & s)
        Next
    End Sub
    Sub IngresoIdentificador(ByRef identificador As SByte)
        Do
            Console.Write("Igrese el n�meno de identificador de ropa (0 para salir): ")
            identificador = Console.ReadLine
        Loop Until ValidarIdentificador(identificador)
    End Sub
    Function ValidarIdentificador(ByRef identificador As SByte) As Boolean
        If identificador >= 0 And identificador <= 6 Then
            Return True
        Else
            Console.WriteLine("N�mero de identificador inv�lido.")
            Return False
        End If
    End Function
    Sub MuestroTama�osDeRopa()
        Console.WriteLine("Tama�os de ropas disponibles.")
        For Each s In GetAllTama�os()
            Console.Write(vbTab & s)
        Next
        Console.WriteLine()
    End Sub
    Sub IngresoTama�osDeRopa(ByRef tama�o As String)
        Do
            Console.Write("Igrese tama�o de ropa: ")
            tama�o = Console.ReadLine
        Loop Until ValidarTama�oDeRopa(tama�o)
    End Sub
    Function ValidarTama�oDeRopa(ByRef tama�o As String) As Boolean
        For Each s In GetAllTama�os()
            If s = tama�o Then
                Return True
            End If
        Next
        Console.WriteLine("Tama�o de ropa ingresado env�lido.")
        Return False
    End Function
    Sub IngresoEgreso(ByRef ingreso_egreso As String)
        Do
            Console.Write("Para ingreso de stock ingrese (+), para egreso ingrese (-): ")
            ingreso_egreso = Console.ReadLine
        Loop Until ValidarIngresoEgreso(ingreso_egreso)
    End Sub
    Function ValidarIngresoEgreso(ByRef ingreso_egreso As String) As Boolean
        If ingreso_egreso = "+" Or ingreso_egreso = "-" Then
            Return True
        Else
            Console.WriteLine("Signo ingresado inv�lido.")
            Return False
        End If
    End Function
    Sub IngresoCantidadDeRopas(ByRef stock_De_Ropas(,) As UShort, ByRef identificador As SByte, ByRef tama�o As String, ByRef ingreso_egreso As String, ByRef cantidad_ropas As Integer)
        Do
            Do
                If ingreso_egreso = "+" Then
                    Console.Write("Igrese cantidad de ropas a sumar al stock: ")
                Else
                    Console.Write("Igrese cantidad de ropas a restar al stock: ")
                End If
                cantidad_ropas = Console.ReadLine
            Loop Until ValidarCantidad(cantidad_ropas)
        Loop Until ingreso_egreso = "+" OrElse ValidarEgreso(stock_De_Ropas, identificador, tama�o, cantidad_ropas)
    End Sub
    Function ValidarCantidad(ByRef cantidad_ropas As Integer) As Boolean
        If cantidad_ropas >= 0 Then
            Return True
        Else
            Console.WriteLine("Cantidad ingresada inv�lido, (debe ser positivo).")
            Return False
        End If
    End Function
    Function ValidarEgreso(stock_De_Ropas(,) As UShort, identificador As Byte, tama�o As String, cantidad_ropas As UShort) As Boolean
        If cantidad_ropas <= stock_De_Ropas(identificador - 1, GetTama�o(tama�o)) Then
            Return True
        Else
            Console.WriteLine("Cantidad ingresada mayor al stock existente. Stock existente: " & stock_De_Ropas(identificador - 1, GetTama�o(tama�o)) & ", Cantidad ingresada: " & cantidad_ropas)
            Return False
        End If
    End Function
    Sub ActualizarStock(ByRef stock_De_Ropas(,) As UShort, ByRef identificador As SByte, ByRef tama�o As String, ByRef ingreso_egreso As String, ByRef cantidad_ropas As Integer)
        If ingreso_egreso = "+" Then
            stock_De_Ropas(identificador - 1, GetTama�o(tama�o)) += cantidad_ropas
        Else
            stock_De_Ropas(identificador - 1, GetTama�o(tama�o)) -= cantidad_ropas
        End If
    End Sub
    Enum Tama�os
        P = 0
        M
        G
    End Enum
    Private Function GetAllTama�os() As String()
        Return [Enum].GetNames(GetType(Tama�os))
    End Function
    Private Function GetTama�o(valor As String) As Integer
        Return CInt([Enum].Parse(GetType(Tama�os), valor))
    End Function
    Private Function GetRopas() As String()
        Dim ropas(5) As String
        ropas(0) = "Camisa hombre lisa"
        ropas(1) = "Pantalon hombre executive"
        ropas(2) = "Short de vestir"
        ropas(3) = "Corbata color liso"
        ropas(4) = "Remera fachion"
        ropas(5) = "Remera playera"
        Return ropas
    End Function
    Private Sub MostrarStock(ByRef stock_De_Ropas(,) As UShort)
        Console.Clear()
        Console.Write("Ropa/Tama�o" & vbCrLf & vbTab)
        For Each tama�o In GetAllTama�os()
            Console.Write(tama�o & vbTab)
        Next
        Console.WriteLine()
        For x = 0 To 5
            Console.Write(x + 1 & vbTab)
            For y = 0 To 2
                Console.Write(stock_De_Ropas(x, y) & vbTab)
            Next
            Console.WriteLine()
        Next
    End Sub
End Module