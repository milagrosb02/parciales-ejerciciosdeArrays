Imports System.Math
Module Program
    Sub Main(args As String())
        Dim tablero(,) As Piezas = GetTablero()
        Dim pieza As Piezas
        'Dim columna As Char
        Dim columna_origen, fila_origen, columa_destino, fila_destino As SByte
        Do
            MostrarTablero(tablero)
            'pieza = IngrezarPieza()
            'Console.WriteLine(IngrezarPieza().ToString)
            Console.WriteLine("Origen")
            columna_origen = IngresarColumna()
            Console.WriteLine(columna_origen)
            'Console.WriteLine(getColumnaIndice(IngresarColumna()))
            fila_origen = IngresarFila()
            'Console.WriteLine(IngresarFila())
            pieza = GetPiezaEnCasilla(tablero, columna_origen, fila_origen)
            Console.WriteLine(pieza.ToString)
            If IsPieza(pieza) Then
                Console.WriteLine("Destino")
                columa_destino = IngresarColumna()
                fila_destino = IngresarFila()
                If GetPiezaEnCasilla(tablero, columa_destino, fila_destino) = Piezas.__ Then
                    If ValidarMovimiento(pieza, columna_origen, fila_origen, columa_destino, fila_destino) Then
                        MoverPieza(tablero, columna_origen, fila_origen, columa_destino, fila_destino)
                        Console.WriteLine("Pieza movida")
                    Else
                        Console.WriteLine("Movimiento inválido")
                    End If
                Else
                    Console.WriteLine("Ya hay pieza en esa posición")
                End If
            Else
                Console.WriteLine("No hay pieza en esa posición")
            End If
            Console.ReadKey()
            'Loop Until EstaPiezaEnCasilla(tablero, pieza, columna_origen, fila_origen)
        Loop While True
    End Sub
    Enum Piezas
        __
        Peón
        Rey
        Dama
        Torre
        Alfil
        Caballo
    End Enum
    Function GetTablero() As Piezas(,)
        Dim tablero(7, 7) As Piezas
        tablero(0, 0) = Piezas.Torre
        tablero(2, 2) = Piezas.Caballo
        tablero(2, 1) = Piezas.Alfil
        tablero(3, 4) = Piezas.Dama
        tablero(5, 5) = Piezas.Rey
        tablero(5, 1) = Piezas.Alfil
        tablero(6, 0) = Piezas.Caballo
        tablero(7, 3) = Piezas.Torre
        tablero(1, 1) = Piezas.Peón
        Return tablero
    End Function
    Private Function IsPieza(pieza As Piezas) As Boolean
        Return pieza <> Piezas.__
    End Function
    Function IngresarColumna() As SByte
        Dim columna As Char
        Do
            Console.Write("Ingrese columna: ")
            columna = Console.ReadLine()
        Loop Until ValidarColumna(columna)
        Return GetIndiceDeColumna(columna)
    End Function
    Function GetIndiceDeColumna(columna As Char) As SByte
        Return AscW(columna) - 97
    End Function
    Function ValidarColumna(columna As Char) As Boolean
        Return columna >= "a" And columna <= "h"
    End Function
    Function IngresarFila() As SByte
        Dim fila As SByte
        Do
            Console.Write("Ingrese fila: ")
            fila = Console.ReadLine()
        Loop Until ValidarFila(fila)
        Return fila - 1
    End Function
    Function ValidarFila(fila As SByte) As Boolean
        Return fila >= 1 And fila <= 8
    End Function
    Function GetPiezaEnCasilla(tablero(,) As Piezas, columna As SByte, fila As SByte) As Piezas
        Return tablero(columna, fila)
    End Function
    Function ValidarMovimiento(pieza As Piezas, columna_origen As SByte, fila_origen As SByte, columna_destino As SByte, fila_destino As SByte) As Boolean
        Console.WriteLine((columna_origen & columna_destino) & " . " & (fila_origen & fila_destino))
        Select Case pieza
            Case Piezas.Alfil
                If Abs(columna_origen - columna_destino) = Abs(fila_origen - fila_destino) Then
                    Return True
                End If
            Case Piezas.Dama
                Return ValidarMovimiento(Piezas.Alfil, columna_origen, fila_origen, columna_destino, fila_destino) Or ValidarMovimiento(Piezas.Torre, columna_origen, fila_origen, columna_destino, fila_destino)
            Case Piezas.Caballo
                If (Abs(columna_origen - columna_destino) = 1 And Abs(fila_origen - fila_destino) = 2) Or (Abs(columna_origen - columna_destino) = 2 And Abs(fila_origen - fila_destino) = 1) Then
                    Return True
                End If
            Case Piezas.Peón
                If columna_origen = columna_destino And fila_origen + 1 = fila_destino Then
                    Return True
                End If
            Case Piezas.Rey
                If Abs(columna_origen - columna_destino) = 1 Or Abs(fila_origen - fila_destino) = 1 Then
                    Return True
                End If
            Case Piezas.Torre
                If (columna_origen = columna_destino And fila_origen <> fila_destino) Or (columna_origen <> columna_destino And fila_origen = fila_destino) Then
                    Return True
                End If
        End Select
        Return False
    End Function
    Sub MoverPieza(tablero(,) As Piezas, columna_origen As SByte, fila_origen As SByte, columna_destino As SByte, fila_destino As SByte)
        tablero(columna_destino, fila_destino) = tablero(columna_origen, fila_origen)
        tablero(columna_origen, fila_origen) = Piezas.__
    End Sub
    Sub MostrarTablero(tablero(,) As Piezas)
        Console.Clear()
        For fila = 7 To 0 Step -1
            Console.Write(fila + 1 & vbTab)
            For columna = 0 To 7 Step 1
                Console.Write(tablero(columna, fila).ToString & vbTab)
            Next
            Console.WriteLine(vbCrLf)
        Next
        For x = 97 To 104
            Console.Write(vbTab & ChrW(x))
        Next
        Console.WriteLine()
    End Sub
End Module