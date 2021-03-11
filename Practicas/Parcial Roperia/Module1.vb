Module Module1

    Enum Tamaños
        P = 1
        M
        G
    End Enum

    Sub Main()

        'VECTOR DE DOS DIMENSIONES

        Dim stock(5, 2) As UShort '5 es por la cantidad de ropas en el vector y 2 por la enumeracion de tamaños

        Dim ropas As String() = GetRopas()

        Dim identificador As SByte

        Dim tamaño As String = ""

        Dim ingreso_egreso As String = ""

        Dim cantidad_ropas As UShort


        'LLAMADAS A FUNCIONES Y SUBRUTINAS

        IterarRopas(ropas)

        IngresarIdentificador(identificador, ropas)

        IterarTamañoRopa()

        IngresarTamañoRopa(tamaño)

        IngresoEgresoRopa(ingreso_egreso)

        IngresarCantidadRopa(stock, identificador, tamaño, ingreso_egreso, cantidad_ropas)

        ActualizarStock(stock, identificador, tamaño, ingreso_egreso, cantidad_ropas)

        MostrarStock(stock)

    End Sub


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

    'PUNTO 9 = CORREGIR ESTA FUNCION PARA MOSTRAR EL VECTOR DE DOS DIMENSIONES (5,2)

    Private Sub MostrarStock(ByRef stock(,) As UShort)
        Console.Clear()
        Console.Write("Ropa/Tamaño" & vbCrLf & vbTab)
        For Each tamaño In GetAllTamaños()
            Console.Write(tamaño & vbTab)
        Next
        Console.WriteLine()
        For x = 0 To 5
            Console.Write(x + 1 & vbTab)
            For y = 0 To 2
                Console.Write(stock(x, y) & vbTab)
            Next
            Console.WriteLine()
        Next
    End Sub

    'PUNTO 3 = MOSTRAR ROPAS (ITERAR VECTOR DE ROPAS)

    Sub IterarRopas(ByRef ropas() As String)

        Dim cont As Byte

        For x = 0 To ropas.Length - 1

            cont += 1

            Console.WriteLine(cont & " " & "-" & " " & ropas(x))

        Next

    End Sub

    'PUNTO 4 A = INGRESAR IDENTIFICADOR DE ROPA QUE CORRESPONDA A UN ELEMENTO DEL VECTOR

    Sub IngresarIdentificador(ByRef identificador As SByte, ByRef ropas() As String)

        Do

            Console.WriteLine("Ingresar codigo de ropa: ")

            identificador = Console.ReadLine()

        Loop Until ValidarIdentificadorRopa(identificador, ropas)


    End Sub

    'PUNTO 4 B = VALIDAR QUE EL IDENTIFICADOR CORRESPONDA A QUE NO SOBREPASE EL RANGO DEL VECTOR Y SEA POSITIVO

    Function ValidarIdentificadorRopa(ByRef identificador As SByte, ByRef ropas() As String) As Boolean

        If identificador <= ropas.Length And identificador >= 0 Then

            Return True

        Else

            Console.WriteLine("Codigo Invalido!")

        End If

        Return False

    End Function

    'PUNTO 5 A = MOSTRAR TAMAñOS DE ROPAS (ITERAR LA ENUMERACION)
    Sub IterarTamañoRopa()

        For Each tam In GetAllTamaños()

            Console.Write(vbTab & tam)

        Next

        Console.WriteLine()

    End Sub

    'PUNTO 5 B = INGRESAR TAMAñO DE ROPA
    Sub IngresarTamañoRopa(ByRef tamaño As String)

        Do

            Console.WriteLine("Ingresar tamaño de ropa P M G: ")

            tamaño = Console.ReadLine()

        Loop Until ValidarTamañoRopa(tamaño)



    End Sub

    'PUNTO 5 C = VALIDAR QUE EL TAMAñO DE ROPA INGRESADO CORRESPONDA A UN NUMERO DE LA ENUMERACION

    Function ValidarTamañoRopa(ByRef tamaño As String) As Boolean

        For Each t In GetAllTamaños()

            If t = tamaño Then

                Return True

            End If

        Next

        Console.WriteLine("Tamaño Inválido!")

        Return False

    End Function

    'PUNTO 6 A = INGRESAR O EGRESAR ROPA

    Sub IngresoEgresoRopa(ByRef ingreso_egreso As String)

        Do

            Console.WriteLine("Ingresar (+) para ingresar ropa o (-) para egresar ropa: ")

            ingreso_egreso = Console.ReadLine()

        Loop Until ValidarCaracter(ingreso_egreso)

    End Sub

    'PUNTO 6 B = VALIDAR QUE EL CARACTER INGRESADO SEA + O -

    Function ValidarCaracter(ByRef ingreso_egreso As String) As Boolean

        If ingreso_egreso = "+" Or ingreso_egreso = "-" Then

            Return True

        Else

            Console.WriteLine("Caracter Invalido!")

            Return False

        End If

    End Function

    'PUNTO 7 A = INGRESAR CANTIDAD DE ROPAS A MOVER

    Sub IngresarCantidadRopa(ByRef stock(,) As UShort, ByRef identificador As SByte, ByRef tamaño As String, ByRef ingreso_egreso As String, ByRef cantidad_ropas As UShort)

        Do

            Do

                If ingreso_egreso = "+" Then

                    Console.WriteLine("Ingresar cantidad de ropas a sumar: ")

                Else

                    Console.WriteLine("Ingrese cantidad de ropas a restar del stock: ")

                End If

                cantidad_ropas = Console.ReadLine()

            Loop Until ValidarCantidadRopas(cantidad_ropas)


        Loop Until ingreso_egreso = "+" OrElse ValidarEgreso(stock, identificador, tamaño, cantidad_ropas)

    End Sub

    'PUNTO 7 B = VALIDAR QUE LA CANTIDAD DE ROPA INGRESADA SEA POSITIVA

    Function ValidarCantidadRopas(ByRef cantidad_ropas As UShort) As Boolean

        If cantidad_ropas >= 0 Then

            Return True

        Else

            Console.WriteLine("El valor debe ser positivo!")

            Return False

        End If

    End Function

    'PUNTO 7 C = VALIDAR SI ES EGRESO, NO SEA MAYOR AL STOCK (ARRAY DE STOCK)
    Function ValidarEgreso(stock(,) As UShort, ByRef identificador As Byte, ByRef tamaño As String, ByRef cantidad_ropas As UShort) As Boolean

        If cantidad_ropas <= stock(identificador - 1, GetTamaño(tamaño)) Then

            Return True

        Else

            Console.WriteLine("Cantidad ingresada mayor al stock existente. Stock existente: " & stock(identificador - 1, GetTamaño(tamaño)) & ", Cantidad ingresada: " & cantidad_ropas)

            Return False

        End If

    End Function

    'PUNTO 8 = ACTUALIZAR VECTOR DE ROPAS (STOCK)

    Sub ActualizarStock(ByRef stock(,) As UShort, ByRef identificador As SByte, ByRef tamaño As String, ByRef ingreso_egreso As String, ByRef cantidad_ropas As String)

        If ingreso_egreso = "+" Then

            stock(identificador - 1, GetTamaño(tamaño)) += cantidad_ropas

        Else

            stock(identificador - 1, GetTamaño(tamaño)) -= cantidad_ropas

        End If

    End Sub

End Module
