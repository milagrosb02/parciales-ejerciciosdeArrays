Imports System
Module Library
    Sub Main()
        Dim stock_De_Ropas(5, 2) As UShort
        Dim identificador As SByte
        Dim tamaño As String = ""
        Dim ingreso_egreso As String = ""
        Dim cantidad_ropas As Integer
        Do
            MostrarRopas()
            IngresoIdentificador(identificador)
            If identificador = 0 Then
                Exit Do
            End If
            MuestroTamañosDeRopa()
            IngresoTamañosDeRopa(tamaño)
            IngresoEgreso(ingreso_egreso)
            IngresoCantidadDeRopas(stock_De_Ropas, identificador, tamaño, ingreso_egreso, cantidad_ropas)
            ActualizarStock(stock_De_Ropas, identificador, tamaño, ingreso_egreso, cantidad_ropas)
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
            Console.Write("Igrese el númeno de identificador de ropa (0 para salir): ")
            identificador = Console.ReadLine
        Loop Until ValidarIdentificador(identificador)
    End Sub
    Function ValidarIdentificador(ByRef identificador As SByte) As Boolean
        If identificador >= 0 And identificador <= 6 Then
            Return True
        Else
            Console.WriteLine("Número de identificador inválido.")
            Return False
        End If
    End Function
    Sub MuestroTamañosDeRopa()
        Console.WriteLine("Tamaños de ropas disponibles.")
        For Each s In GetAllTamaños()
            Console.Write(vbTab & s)
        Next
        Console.WriteLine()
    End Sub
    Sub IngresoTamañosDeRopa(ByRef tamaño As String)
        Do
            Console.Write("Igrese tamaño de ropa: ")
            tamaño = Console.ReadLine
        Loop Until ValidarTamañoDeRopa(tamaño)
    End Sub
    Function ValidarTamañoDeRopa(ByRef tamaño As String) As Boolean
        For Each s In GetAllTamaños()
            If s = tamaño Then
                Return True
            End If
        Next
        Console.WriteLine("Tamaño de ropa ingresado enválido.")
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
            Console.WriteLine("Signo ingresado inválido.")
            Return False
        End If
    End Function
    Sub IngresoCantidadDeRopas(ByRef stock_De_Ropas(,) As UShort, ByRef identificador As SByte, ByRef tamaño As String, ByRef ingreso_egreso As String, ByRef cantidad_ropas As Integer)
        Do
            Do
                If ingreso_egreso = "+" Then
                    Console.Write("Igrese cantidad de ropas a sumar al stock: ")
                Else
                    Console.Write("Igrese cantidad de ropas a restar al stock: ")
                End If
                cantidad_ropas = Console.ReadLine
            Loop Until ValidarCantidad(cantidad_ropas)
        Loop Until ingreso_egreso = "+" OrElse ValidarEgreso(stock_De_Ropas, identificador, tamaño, cantidad_ropas)
    End Sub
    Function ValidarCantidad(ByRef cantidad_ropas As Integer) As Boolean
        If cantidad_ropas >= 0 Then
            Return True
        Else
            Console.WriteLine("Cantidad ingresada inválido, (debe ser positivo).")
            Return False
        End If
    End Function
    Function ValidarEgreso(stock_De_Ropas(,) As UShort, identificador As Byte, tamaño As String, cantidad_ropas As UShort) As Boolean
        If cantidad_ropas <= stock_De_Ropas(identificador - 1, GetTamaño(tamaño)) Then
            Return True
        Else
            Console.WriteLine("Cantidad ingresada mayor al stock existente. Stock existente: " & stock_De_Ropas(identificador - 1, GetTamaño(tamaño)) & ", Cantidad ingresada: " & cantidad_ropas)
            Return False
        End If
    End Function
    Sub ActualizarStock(ByRef stock_De_Ropas(,) As UShort, ByRef identificador As SByte, ByRef tamaño As String, ByRef ingreso_egreso As String, ByRef cantidad_ropas As Integer)
        If ingreso_egreso = "+" Then
            stock_De_Ropas(identificador - 1, GetTamaño(tamaño)) += cantidad_ropas
        Else
            stock_De_Ropas(identificador - 1, GetTamaño(tamaño)) -= cantidad_ropas
        End If
    End Sub
    Enum Tamaños
        P = 0
        M
        G
    End Enum
    Private Function GetAllTamaños() As String()
        Return [Enum].GetNames(GetType(Tamaños))
    End Function
    Private Function GetTamaño(valor As String) As Integer
        Return CInt([Enum].Parse(GetType(Tamaños), valor))
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
        Console.Write("Ropa/Tamaño" & vbCrLf & vbTab)
        For Each tamaño In GetAllTamaños()
            Console.Write(tamaño & vbTab)
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