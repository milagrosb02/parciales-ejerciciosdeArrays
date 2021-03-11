Module Library


    Friend Function GetAllTamaños() As String()
        Return [Enum].GetNames(GetType(Tamaños))
    End Function


    Friend Function GetTamaño(valor As String) As Integer
        Return CInt([Enum].Parse(GetType(Tamaños), valor))
    End Function


    Friend Function getRopas() As String()
        Dim ropas(5) As String
        ropas(0) = "Camisa hombre lisa"
        ropas(1) = "Pantalon hombre executive"
        ropas(2) = "Short de vestir"
        ropas(3) = "Corbata color liso"
        ropas(4) = "Remera fachion"
        ropas(5) = "Remera playera"
        Return ropas
    End Function


    Sub MostrarStock(Stock(,) As UShort)
        Console.Clear()
        Console.WriteLine("MostrarStock() : ")

        Console.Write("Ropa/Tamaño" & vbCrLf & vbTab)

        For Each tamaño In GetAllTamaños()
            Console.Write(tamaño & vbTab)
        Next

        Console.WriteLine() ' escibe un vacio

        'da el indice del ultimo elemento de la dimension especificada entre parentesis
        For x = 0 To Stock.GetUpperBound(0)
            Console.Write(x + 1 & vbTab)

            For y = 0 To Stock.GetUpperBound(1)

                Console.Write(Stock(x, y) & vbTab)
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
