Imports System

Module Roperia
    Friend Enum Tamaños
        P = 0
        M
        G
    End Enum


    Sub Main()
        Dim codigoRopa As Byte
        Dim tamaño As Tamaños
        Dim cantidadIngresada As Short
        Dim tipoMovimiento As Char
        Dim Stock(5, 2) As UShort

        Do
            MostrarStock(Stock)
            Console.WriteLine()
            MostrarRopas()
            Console.WriteLine()
            IngresoIDRopa(codigoRopa)

            If codigoRopa > 0 Then
                IngresoLetraTamaño(tamaño)
                ElegirIngresoEgreso(tipoMovimiento)
                IngresoRopasMover(cantidadIngresada, tipoMovimiento, Stock, codigoRopa, tamaño)
                ActualizarStock(cantidadIngresada, tipoMovimiento, Stock, codigoRopa, tamaño)
            End If

        Loop Until codigoRopa = 0
        Console.WriteLine()
    End Sub


    Sub MostrarRopas()

        Dim contador As Byte
        Console.WriteLine("MostrarRopas() :")
        For Each ropa In getRopas()
            contador += 1
            Console.WriteLine(contador & " - " & ropa)
        Next
        Console.WriteLine()
    End Sub



    Sub IngresoIDRopa(ByRef codigoRopa As Byte)

        Do
            Console.WriteLine("Ingrese ID de Ropa: ")
            codigoRopa = Console.ReadLine()

        Loop Until validarIDRopa(codigoRopa)
    End Sub
    Function validarIDRopa(codigoRopa As Byte) As Boolean

        If codigoRopa > 0 And codigoRopa < getRopas().Count + 1 Then
            Return True
        Else
            Console.WriteLine("ERROR DE INGRESO.")
            Return False
        End If

    End Function


    Sub IngresoLetraTamaño(ByRef tamaño As Tamaños)
        Console.WriteLine()

        ' muestro tamaños disponibles
        Console.Write("Ropa/Tamaño" & vbCrLf)
        For Each letraBase As Char In GetAllTamaños()
            Console.Write(letraBase & vbTab)
        Next

        Dim letraIngresada As Char

        Do
            Console.WriteLine(vbCrLf & "Ingrese la LETRA del Tamaño de ropa: ")
            letraIngresada = Console.ReadLine()

        Loop Until validarIDTamaño(letraIngresada)

        ' paso a mayusculas , por si se habia ingresado en minusculas
        tamaño = GetTamaño(Char.ToUpper(letraIngresada))

    End Sub

    Function validarIDTamaño(letraIngresada As Char) As Boolean
        If GetAllTamaños.Contains(Char.ToUpper(letraIngresada)) Then

            Return True
        Else
            Console.Write("ERROR DE INGRESO.")
            Return False
        End If
        ' OTRA FORMA DE HACER
        'For Each letraBase In GetAllTamaños()
        '    If letraBase = Char.ToUpper(letraIngresada) Then
        '        Return True
        '    End If
        'Next
        'Console.WriteLine("ERROR DE INGRESO.")
        'Return False
    End Function


    Sub ElegirIngresoEgreso(ByRef tipoMovimiento)
        Console.WriteLine()
        Do
            Console.WriteLine("Ingrese '+' para un ingreso o '-' para un egreso: ")
            tipoMovimiento = Console.ReadLine()
        Loop Until validarSignoMovimiento(tipoMovimiento)
    End Sub

    Function validarSignoMovimiento(value As Char) As Boolean
        If value = "+" Or value = "-" Then
            Return True
        Else
            Console.WriteLine("ERROR DE INGRESO.")
            Return False
        End If
    End Function



    Sub IngresoRopasMover(ByRef cantidadIngresada As Short, ByRef tipoMovimiento As Char, Stock(,) As UShort, codigoRopa As Byte, tamaño As Tamaños)
        Console.WriteLine()
        Do
            Console.WriteLine("Ingrese la Cantidad de Ropas a mover: ")
            cantidadIngresada = Console.ReadLine()
        Loop Until (validarRopasMover(cantidadIngresada, tipoMovimiento, Stock, codigoRopa, tamaño))
    End Sub


    Function validarRopasMover(cantidadIngresada As Short, tipoMovimiento As Char, Stock(,) As UShort, codigoRopa As Byte, tamaño As Tamaños) As Boolean

        If cantidadIngresada < 0 Then
            Console.WriteLine("ERROR DE CANTIDAD.")
            Return False
        ElseIf tipoMovimiento = "-" And cantidadIngresada > Stock(codigoRopa - 1, tamaño) Then
            Console.WriteLine("INSUFICIENTE STOCK.")
            Return False
        End If
        Return True
    End Function


    Sub ActualizarStock(cantidadIngresada As Short, tipoMovimiento As Char, ByRef Stock(,) As UShort, codigoRopa As Byte, tamaño As Tamaños)
        If tipoMovimiento = "+" Then
            Stock(codigoRopa - 1, tamaño) += cantidadIngresada
        ElseIf tipoMovimiento = "-" Then
            Stock(codigoRopa - 1, tamaño) -= cantidadIngresada
        End If
        MostrarStock(Stock)
    End Sub
End Module
