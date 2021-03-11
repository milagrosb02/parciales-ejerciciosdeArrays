Module Module1

    Enum Albumes

        A = 0

        B

        K

        S

        M

    End Enum

    Sub Main()

        'Se declara el array sin nada para asi poder llamarlo

        Dim cancion As String() = CancionesTheWeeknd() 'Llamo a la funcion del array con el mismo nombre que la variable que declare

        Dim identificador As SByte

        Dim album As Albumes

        'LLAMANDO A SUBRUTINAS Y PROCEDIMIENTOS

        MostrarCanciones(cancion)

        IngresarIdentificador(identificador)

        MostrarAlbumes()



    End Sub

    'Funcion para crear un array cargado programaticamente

    Function CancionesTheWeeknd() As String()

        'Crear array de 5 elementos

        'Siempre cuando tenga que crear un array de 1 dimension PRESTAR ATENCION A LA CANTIDAD DE ELEMENTOS QUE PIDES, ENTONCES SE LE RESTA -1 ANTES DE DECLARAR

        Dim cancion(4) As String

        cancion(0) = "Earned It"

        cancion(1) = "The Hills"

        cancion(2) = "In The Night"

        cancion(3) = "In Your Eyes"

        cancion(4) = "Blinding Lights"

        Return cancion

    End Function

    Sub MostrarCanciones(cancion() As String)

        'Declaro un contador para que cuente cada vez que itera

        Dim contador As Byte = 0

        'ITERACION DEL VECTOR CANCION() CON FOR COMUN

        For x = 0 To cancion.Length - 1

            contador += 1

            'Console.WriteLine(x + 1 & "-" & " " & cancion(x))

            Console.WriteLine(contador & "-" & cancion(x))

        Next


        'ITERACION DEL VECTOR CANCION() CON FOR EACH

        'For Each tema In cancion

        '    contador += 1

        '    Console.WriteLine(contador & "-" & tema)

        'Next

    End Sub

    Sub IngresarIdentificador(ByRef identificador As SByte)

        Do
            Console.WriteLine("Ingresar codigo de cancion: ")

            identificador = Console.ReadLine()

        Loop Until ValidarIdentificador(identificador)



    End Sub

    Function ValidarIdentificador(ByRef identificador As SByte) As Boolean

        If identificador >= 0 And identificador <= 4 Then

            Return True

        Else

            Console.WriteLine("El codigo es invalido!")

            Return False

        End If

    End Function

    'ESTA FUNCION RETORNA LO QUE ESTA EN LA ENUMERACION

    Function GetAllAlbumes() As String()

        Return [Enum].GetNames(GetType(Albumes))

    End Function

    Function GetTamaño(valor As String) As Integer

        Return CInt([Enum].Parse(GetType(Albumes), valor))

    End Function

    Sub MostrarAlbumes()

        'ITERACION DE LA ENUMERACION DE ALBUMES

        Console.WriteLine("Albumes disponibles: ")

        For Each album In GetAllAlbumes()

            Console.WriteLine(vbTab & album)

        Next

    End Sub

    'Sub IngresarCodigoAlbum(ByRef album As Albumes)

    '    Do

    '        Console.WriteLine("Ingresar inicial de album: ")

    '        album = Console.ReadLine()

    '    Loop Until ValidarCodigoAlbum()


    'End Sub

    'Function ValidarCodigoAlbum(ByRef ) As Boolean



    'End Function
End Module
