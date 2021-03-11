Module Module1


    Sub Main()

        Dim codigos = New Byte() {1, 2, 3}

        Dim productos = New String() {"arveja", "choclo", "sal"}

        Dim precios = New Decimal() {70.5, 80.8, 40.5}


        Dim codigoProducto As Byte

        Dim cantidad As UShort

        Dim totalDeVenta, totalGeneral, aux_Precio As Decimal

        Do

            IngresarCodigo(codigos, codigoProducto)

            'PUNTO 1 C = MUESTRA LA DESCRIPCION DEL CODIGO DEL PRODUCTO INGRESADO

            If ValidarCodigoProducto(codigos, codigoProducto) = True Then

                'RECORRE LA LONGITUD DEL ARRAY DE CODIGOS

                For x = 0 To codigos.Length - 1

                    'COMPARA SI EL CODIGO DE PRODUCTO INGRESADO ES IGUAL AL DE CODIGOS (Y LE PASA EL INDICE DEL ITERADOR)

                    If codigoProducto = codigos(x) Then

                        'IMPRIME EL PRODUCTO CORRESPONDIENTE AL CODIGO INGRESADO (LE PASA EL ARRAY JUNTO AL INDICE)

                        Console.WriteLine("Producto: " & productos(x))

                        Console.WriteLine("Precio: " & precios(x))

                        aux_Precio = precios(x)

                    End If

                Next

                Console.WriteLine("Ingresar cantidad de productos a comprar: ")

                cantidad = Console.ReadLine()

                totalDeVenta = aux_Precio * cantidad

                totalGeneral += totalDeVenta

                Console.WriteLine("El total de este producto es: " & " " & "$" & totalGeneral)

            End If

        Loop While codigoProducto <> 0

    End Sub

    'PUNTO 1 A = INGRESAR CODIGO DE PRODUCTO

    Sub IngresarCodigo(ByRef codigos() As Byte, ByRef codigoProducto As Byte)

        Do

            Console.WriteLine("Ingresar un codigo de producto: ")

            codigoProducto = Console.ReadLine()

        Loop Until ValidarCodigoProducto(codigos, codigoProducto)

    End Sub

    'PUNTO 1 B = VALIDAR QUE EL CODIGO INGRESADO SEA DEL ARRAY DE CODIGOS 

    Function ValidarCodigoProducto(ByRef codigos() As Byte, ByRef codigoProducto As Byte) As Boolean

        For Each c In codigos

            If c = codigoProducto Then

                Return True

            End If

        Next

        Console.WriteLine("Codigo Invalido!")

        Return False

    End Function

End Module
