Module Module1

    'Parcial del Ticket del 2019 (Noviembre)

    Sub Main()

        'Array de 7 numeros

        'Se ingresan 4 numeros y 3 letras 

        Dim ticket(6) As String

        Dim tickets(6, 6) As Char


        IngresarTicketNumero(ticket)

        IngresarTicketLetra(ticket)

        Ordenar(ticket)


    End Sub

    Sub IngresarTicketNumero(ByRef ticket() As String)

        Dim x As SByte = 0

        Dim valor As SByte

        'Posicion de 0 hasta 3 se ingresan numeros
        For x = 0 To 3

            Do

                Console.WriteLine("Ingrese numero (" & x + 1 & "): ")

                valor = Console.ReadLine()

            Loop Until ValidarNumero(valor, ticket)

            ticket(x) = valor 'el valor que se ingreso le mando al indice del array (x)

        Next

    End Sub


    Function ValidarNumero(ByRef valor As String, ByRef ticket() As String) As Boolean

        Dim x As SByte

        For x = 0 To 3

            If valor = ticket(x) Or valor > 10 Then

                Console.WriteLine("Numero invalido!")

                Return False

            End If

        Next

        Return True

    End Function


    Sub IngresarTicketLetra(ByRef ticket() As String)

        Dim x As SByte

        Dim y As SByte 'contador

        Dim letra As Char

        'Posicion de 4 a 6 se ingresan letras

        For x = 4 To 6

            y += 1

            Do

                Console.Write("Ingresar letra: (" & y & "): ")

                'Se ingresan 4 letras entre A y F

                letra = Console.ReadLine()

            Loop Until ValidarLetra(letra, ticket)

            ticket(x) = letra 'el valor que se ingreso le mando al indice del array (x)

        Next

    End Sub


    Function ValidarLetra(ByRef letra As Char, ByRef ticket() As String) As Boolean

        For x = 4 To 6

            'If letra = ticket(x) Or letra < "A" Or letra > "F" Then

            If letra = ticket(x) Or letra > "F" Then

                Console.WriteLine("Letra invalida!")

                Return False

            End If

        Next

        Return True

    End Function


    Sub Ordenar(ByRef ticket() As String)

        Dim aux As Double

        Dim i, j As Integer

        For i = 0 To ticket.Length - 1

            For j = 3 To ticket.Length - i - 1

                If (ticket(j) > ticket(j + 1)) Then

                    aux = ticket(j + 1)

                    ticket(j + 1) = ticket(j)

                    ticket(j) = aux

                End If

            Next

        Next


    End Sub

End Module
