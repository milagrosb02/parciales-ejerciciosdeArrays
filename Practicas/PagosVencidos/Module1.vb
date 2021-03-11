Module Module1

    Sub Main()

        Dim fecha As Date

        Dim fechaFutura As Date = Date.Today

        Dim meses As Byte

        IngresarFecha(fecha, fechaFutura)

        IngresarCantidadMeses(meses)

        MostrarListaFechas(meses, fecha)


    End Sub

    'PUNTO 1 = INGRESAR UNA FECHA

    Sub IngresarFecha(ByRef fecha As Date, ByRef fechaFutura As Date)

        Do

            Console.WriteLine("Ingresar una fecha a futuro: ")

            fecha = Console.ReadLine()

        Loop Until ValidarFechaFutura(fecha, fechaFutura)

    End Sub

    'PUNTO 1 B = VALIDAR QUE LA FECHA INGRESADA SEA A FUTURO

    Function ValidarFechaFutura(ByRef fecha As Date, ByRef fechaFutura As Date) As Boolean

        If fecha > fechaFutura Then

            Return True

        Else

            Console.WriteLine("Fecha Invalida!")

        End If

        Return False

    End Function

    'PUNTO 2 A = INGRESAR CANTIDAD DE MESES

    Sub IngresarCantidadMeses(ByRef meses As Byte)

        Do

            Console.WriteLine("Ingresar cantidad de meses: ")

            meses = Console.ReadLine()

        Loop Until ValidarCantidadMeses(meses)


    End Sub

    'PUNTO 2 B = VALIDAR QUE LOS MESES SEAN MAYOR A 0 Y MENOR A 60

    Function ValidarCantidadMeses(ByRef meses As Byte) As Boolean

        If meses > 0 And meses <= 60 Then

            Return True

        Else

            Console.WriteLine("Cantidad Invalida!")

        End If

        Return False

    End Function

    'PUNTO 3 = MOSTRAR LISTA DE FECHAS EMPEZANDO POR EL SIGUIENTE MES

    Sub MostrarListaFechas(ByRef meses As Byte, ByRef fecha As Date)

        Console.WriteLine("LISTA DE FECHAS: ")

        For x = 1 To meses

            Console.WriteLine(x + 1 & " " & " - " & " " & fecha.AddMonths(x) & " " & " " & fecha.AddMonths(x).ToString("dddd"))

        Next

    End Sub

End Module
