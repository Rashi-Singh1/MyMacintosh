Public Class Form1
    ''' <summary>
    ''' 
    '''    Group Number: 21
    '''    Member 1:
    '''         Rashi Singh
    '''         170101052
    '''    Member 2:
    '''         Kiran Kadam
    '''         170101027
    '''    Member 3:
    '''         Thahir Mahmood
    '''         170101070 
    ''' 
    ''' Implementing the infix calculator aimed for stakeholders - school children and college students,  this application provides the utilities - addition, subtraction, division and multiplication
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Text = RichTextBox1.Text & "1"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Text = RichTextBox1.Text & "2"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Text = RichTextBox1.Text & "3"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RichTextBox1.Text = RichTextBox1.Text & "4"

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RichTextBox1.Text = RichTextBox1.Text & "5"

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox1.Text = RichTextBox1.Text & "6"

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.Text = RichTextBox1.Text & "7"

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RichTextBox1.Text = RichTextBox1.Text & "8"

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        RichTextBox1.Text = RichTextBox1.Text & "9"

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Divide.Click
        RichTextBox1.Text = RichTextBox1.Text & "/"

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Multiply.Click
        RichTextBox1.Text = RichTextBox1.Text & "*"

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Subtract.Click
        RichTextBox1.Text = RichTextBox1.Text & "-"

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Add.Click
        RichTextBox1.Text = RichTextBox1.Text & "+"

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Right_Bracket.Click
        RichTextBox1.Text = RichTextBox1.Text & ")"

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Left_Bracket.Click
        RichTextBox1.Text = RichTextBox1.Text & "("

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Equal.Click

        'calling the function final answer on clicking "="
        Dim is_erase As Boolean = final_ans()

        'If the infix expression is wrong, answer won't be returned, therefore clear both the input and output
        If is_erase = False Then
            RichTextBox2.Clear()
            RichTextBox1.Clear()
        End If

    End Sub

    Private Sub Decimal_point_Click(sender As Object, e As EventArgs) Handles Decimal_point.Click
        RichTextBox1.Text = RichTextBox1.Text & "."

    End Sub

    Private Sub Clear_Screen_Click(sender As Object, e As EventArgs) Handles Clear_Screen.Click

        'when the AC button is pressed, clear the input and output textBox
        RichTextBox1.Text = ""
        RichTextBox2.Text = ""

    End Sub

    Private Sub backspace_Click(sender As Object, e As EventArgs) Handles backspace.Click

        'When del button is pressed, remove last character from the input textbox
        RichTextBox1.Text = RichTextBox1.Text.Remove(RichTextBox1.Text.Count - 1)

    End Sub

    Private Sub Button_0_Click(sender As Object, e As EventArgs) Handles Button_0.Click
        RichTextBox1.Text = RichTextBox1.Text & "0"

    End Sub

Private Function final_ans() As Boolean
        Try

            'Append "=" at the end : Cause at line 
            RichTextBox1.Text = RichTextBox1.Text & "="

            'Name            : input string
            'Stack_Numbers   : (for infix calculation) stack to store decimal numbers given in input
            'Stack_Operators : (for infix calculation) stack to store operators given in input
            'numbers         : list to store decimal numbers given in the string
            'index           : Integer to tell which decimal from list - numbers is to be used
            'tempTrash       : string to store character which occured before the current c (initially set to "\")
            'i1              : integer index to traverse over input string
            'TrashChar       : Char to store previous char from name string in second for loop
            'flg             : integer whose value is 1 if temp is a negative number
            'indexList       : Stores the index in name string where flg is 1

            Dim name As String = RichTextBox1.Text
            Dim c As Char
            Dim Stack_Numbers As Stack(Of Decimal) = New Stack(Of Decimal)
            Dim Stack_Operators As Stack(Of Char) = New Stack(Of Char)
            Dim index As Integer = 0
            Dim TrashChar As Char = "("
            Dim numbers As List(Of Decimal) = New List(Of Decimal)
            Dim temp As String = ""
            Dim tempTrash As String = "\"
            Dim flg As Integer = 0
            Dim indexList As List(Of Integer) = New List(Of Integer)
            Dim i1 As Integer = 0

            'Running loop on name string to split decimals out of the string
            While i1 < name.Length
                Select Case name(i1)

                    'error msg if letters are entered
                    Case "a" To "z", "A" To "Z"
                        MessageBox.Show("No letters allowed", "ERROR")
                        RichTextBox1.Text = ""
                        Return False
                        Exit While
                        Application.Restart()

                        'In case, it is any operator, add non-zero-length valid strings as decimal into the list numbers 
                    Case "(", ")", "+", "/", "-", "*", "="

                        'for special case of getting - as character
                        If name(i1) = "-" Then

                            'check if previous character was a character, if so add the - to the string to form a negative number and set flg=1 and add the index to indexlist
                            Select Case tempTrash
                                Case "(", "*", "/", "+", "-", "\"
                                    temp = "-"
                                    flg = 1
                                    indexList.Add(i1)
                            End Select
                        End If

                        'in case of numbers like 0001 or .112, the function CDec(to convert string to decimal)
                        'automatically removes and adds zero respectively, leading to diff in temp and numbers
                        If temp.Length > 0 And temp <> "-" Then
                            Dim New_string As String = CStr(CDec(temp))

                            'check if temp and decimal rep of temp are same or not
                            If New_string.Length <> temp.Length Then

                                'replace temp with its alternative new_string
                                name = name.Substring(0, i1 - temp.Length) + New_string + name.Substring(i1, name.Length - i1)

                                'also change the index i1 to correctly read the remaining characters
                                If New_string.Length > temp.Length Then
                                    i1 = New_string.Length - temp.Length + i1
                                Else
                                    i1 = i1 - (temp.Length - New_string.Length)
                                End If
                            End If

                            'finally add the decimal version of temp to numbers list
                            numbers.Add(CDec(temp))
                        End If

                        'make flg zero again to check for next characters
                        If flg <> 0 Then
                            flg = 0
                        Else

                            'in case "-" is not included in the number, decimal is ended and temp made "" for next decimal
                            temp = ""
                        End If

                        'in case of numbers or decimal, concatenate it to string temp
                    Case "0" To "9", "."
                        temp = temp & name(i1)
                    Case Else

                        'in case of any other character, show error message
                        MessageBox.Show("Wrong Input", "ERROR")
                        RichTextBox1.Text = ""
                        Return False
                        Exit While
                        Application.Restart()
                End Select

                'to update the previous character
                tempTrash = name(i1)
                i1 += 1
            End While

            'minusOrNot is an integer to maintain which index out of indexlist is being used
            Dim minusOrNot As Integer = 0

            'Basic ALGO:

            '1) If the encountered character is number, push the list value at index from numbers into stack_numbers and jump i(for index) by the length of the number 

            '2) If any operator is encountered, push it in if no operator with higher precedence is present at the top of the stack_operators

            '3) If operator with higher precedence is present at the top, pop two numbers, pop one operator and push in the result, till operator with lower precedence is obtained at the top of stack_operators

            '4) After this, repeat the process till all operators are used and only one number(which is the result) remains in the stack_numbers

            'Second loop over name to solve the infix expression
            For i = 0 To (name.Length - 2)
                Select Case name(i)
                    Case "0" To "9"
                        Select Case TrashChar

                            'If the last character was ")", the push "*" then ")"
                            Case ")"
                                Stack_Operators.Push("*")
                        End Select

                        'Code for step 1 from BASIC ALGO
                        If index < numbers.Count Then
                            Stack_Numbers.Push(numbers(index))
                            TrashChar = name(i)
                            i = i + CStr(numbers(index)).Length - 1
                            index = index + 1
                            Continue For
                        Else
                            MessageBox.Show("Wrong Input", "ERROR")
                            RichTextBox1.Text = ""
                            Return False
                            Exit For
                            Stop
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Case "("

                        'in case of number before "(", first push "*", then push "("
                        Select Case TrashChar
                            Case "0" To "9"
                                Stack_Operators.Push("*")
                        End Select
                        Stack_Operators.Push("(")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Case "/"
                        If (Stack_Operators.Count > 0) Then

                            'If top operator is "/", then pop it and two numbers(must be present), and push the result
                            If Stack_Operators.Peek() = "/" Then
                                If Stack_Numbers.Count() < 2 Then
                                    MessageBox.Show("Wrong Input", "ERROR")
                                    RichTextBox1.Text = ""
                                    Return False
                                    Exit For
                                    Stop
                                Else
                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                    Stack_Operators.Pop()

                                    'adding the condition of not dividing by zero
                                    If num1 = 0 Then
                                        MessageBox.Show("Cnt divide by 0", "ERROR")
                                        RichTextBox1.Text = ""
                                        Return False
                                        Exit For
                                        Stop
                                    Else
                                        Stack_Numbers.Push(num2 / num1)
                                    End If
                                End If
                            Else
                                'push "/" in case of other operators
                                Stack_Operators.Push("/")
                            End If
                        Else
                            'push "/" in case of empty stack_operator
                            Stack_Operators.Push("/")
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''
                        'case of "*" is similar to "/", check for "*", "/" at peek of stack
                    Case "*"
                        Dim alarm As Integer = 0
                        If (Stack_Operators.Count > 0) Then
                            Select Case Stack_Operators.Peek()
                                Case "/"
                                    If Stack_Numbers.Count() < 2 Then
                                        MessageBox.Show("Wrong Input3", "ERROR")
                                        RichTextBox1.Text = ""
                                        Return False
                                        Exit For
                                        Stop
                                    Else
                                        Dim num1 As Decimal = Stack_Numbers.Pop()
                                        Dim num2 As Decimal = Stack_Numbers.Pop()
                                        Stack_Operators.Pop()
                                        If num1 = 0 Then
                                            MessageBox.Show("Cnt divide by 0", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Stack_Numbers.Push(num2 / num1)
                                        End If
                                    End If
                                Case "*"
                                    If Stack_Numbers.Count() < 2 Then
                                        MessageBox.Show("Wrong Input4", "ERROR")
                                        RichTextBox1.Text = ""
                                        Return False

                                        Exit For
                                        Stop
                                    Else
                                        Dim num1 As Decimal = Stack_Numbers.Pop()
                                        Dim num2 As Decimal = Stack_Numbers.Pop()
                                        If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                            MessageBox.Show("Enter a smaller input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Stack_Numbers.Push(num2 * num1)
                                        End If
                                    End If
                                Case Else
                                    Stack_Operators.Push("*")
                                    alarm = 1
                            End Select
                        Else
                            Stack_Operators.Push("*")

                            'in cases of having / and then * at top of stack, need to repeat the process again
                            'but in case of * already pushed in the stack, do not need to repeat the process, hence the integer alarm is used
                            alarm = 1
                        End If
                        If alarm = 0 Then
                            If (Stack_Operators.Count > 0) Then
                                Select Case Stack_Operators.Peek()
                                    Case "/"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False
                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            If num1 = 0 Then
                                                MessageBox.Show("Cnt divide by 0", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False
                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 / num1)
                                            End If
                                            Stack_Operators.Pop()
                                            Stack_Operators.Push("*")
                                        End If
                                    Case "*"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False
                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                MessageBox.Show("Enter a smaller input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False
                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 * num1)
                                            End If
                                            Stack_Operators.Pop()
                                            Stack_Operators.Push("*")
                                        End If
                                    Case Else
                                        Stack_Operators.Push("*")
                                End Select
                            Else
                                Stack_Operators.Push("*")
                            End If
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''
                        'Case of - is similar to case of "/" and case of "*", check for "*", "/" and "-" as the peek to pop and push the result
                    Case "-"
                        If minusOrNot < indexList.Count Then
                            ' check if the "-" sign is part of decimal or not, if not then repeat above procedure else push the number into stack_number and jump by the length of the decimal
                            If indexList(minusOrNot) = i Then
                                If index < numbers.Count Then
                                    Stack_Numbers.Push(numbers(index))
                                    TrashChar = name(i)
                                    i = i + CStr(numbers(index)).Length - 1
                                    index = index + 1
                                    Continue For
                                Else
                                    MessageBox.Show("Wrong Input", "ERROR")
                                    RichTextBox1.Text = ""
                                    Return False

                                    Exit For
                                    Stop
                                End If
                                minusOrNot = minusOrNot + 1
                            Else
                                Dim alarm As Integer = 0
                                If (Stack_Operators.Count > 0) Then
                                    Select Case Stack_Operators.Peek()
                                        Case "/"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                If num1 = 0 Then
                                                    MessageBox.Show("Cnt divide by 0", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 / num1)
                                                End If
                                            End If
                                        Case "*"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                    MessageBox.Show("Enter a smaller input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 * num1)
                                                End If
                                            End If
                                        Case "-"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                Stack_Numbers.Push(num2 - num1)
                                            End If
                                        Case Else
                                            Stack_Operators.Push("-")
                                            alarm = 1

                                    End Select
                                Else
                                    Stack_Operators.Push("-")
                                    alarm = 1
                                End If
                                '''''''
                                'Similar to the case if "*", alarm integer is used to check if "-" is pushed or not
                                If alarm = 0 Then
                                    If (Stack_Operators.Count > 0) Then
                                        Select Case Stack_Operators.Peek()
                                            Case "/"
                                                If Stack_Numbers.Count() < 2 Then
                                                    MessageBox.Show("Wrong Input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                                    Stack_Operators.Pop()
                                                    If num1 = 0 Then
                                                        MessageBox.Show("Cnt divide by 0", "ERROR")
                                                        RichTextBox1.Text = ""
                                                        Return False

                                                        Exit For
                                                        Stop
                                                    Else
                                                        Stack_Numbers.Push(num2 / num1)
                                                    End If
                                                End If
                                            Case "*"
                                                If Stack_Numbers.Count() < 2 Then
                                                    MessageBox.Show("Wrong Input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                                    Stack_Operators.Pop()
                                                    If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                        MessageBox.Show("Enter a smaller input", "ERROR")
                                                        RichTextBox1.Text = ""
                                                        Return False

                                                        Exit For
                                                        Stop
                                                    Else
                                                        Stack_Numbers.Push(num2 * num1)
                                                    End If
                                                End If
                                            Case "-"
                                                If Stack_Numbers.Count() < 2 Then
                                                    MessageBox.Show("Wrong Input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                                    Stack_Operators.Pop()
                                                    Stack_Numbers.Push(num2 - num1)
                                                End If
                                            Case Else
                                                Stack_Operators.Push("-")
                                                alarm = 1
                                        End Select
                                    Else
                                        Stack_Operators.Push("-")
                                        alarm = 1
                                    End If
                                End If

                                ''''''''
                                'Repeating the process for the third time, bcs stack can have atmost 3 operators to process before pushing in "-", which are "/","*","-", in the same order
                                If alarm = 0 Then
                                    If (Stack_Operators.Count > 0) Then
                                        Select Case Stack_Operators.Peek()
                                            Case "/"
                                                If Stack_Numbers.Count() < 2 Then
                                                    MessageBox.Show("Wrong Input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                                    If num1 = 0 Then
                                                        MessageBox.Show("Cnt divide by 0", "ERROR")
                                                        RichTextBox1.Text = ""
                                                        Return False

                                                        Exit For
                                                        Stop
                                                    Else
                                                        Stack_Numbers.Push(num2 / num1)
                                                    End If
                                                    Stack_Operators.Pop()
                                                    Stack_Operators.Push("-")
                                                End If
                                            Case "*"
                                                If Stack_Numbers.Count() < 2 Then
                                                    MessageBox.Show("Wrong Input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                                    If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                        MessageBox.Show("Enter a smaller input", "ERROR")
                                                        RichTextBox1.Text = ""
                                                        Return False

                                                        Exit For
                                                        Stop
                                                    Else
                                                        Stack_Numbers.Push(num2 * num1)
                                                    End If
                                                    Stack_Operators.Pop()
                                                    Stack_Operators.Push("-")
                                                End If
                                            Case "-"
                                                If Stack_Numbers.Count() < 2 Then
                                                    MessageBox.Show("Wrong Input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Dim num1 As Decimal = Stack_Numbers.Pop()
                                                    Dim num2 As Decimal = Stack_Numbers.Pop()
                                                    Stack_Operators.Pop()
                                                    Stack_Numbers.Push(num2 - num1)
                                                    Stack_Operators.Push("-")
                                                End If
                                            Case Else
                                                Stack_Operators.Push("-")
                                        End Select
                                    Else
                                        Stack_Operators.Push("-")
                                    End If
                                End If
                            End If
                        Else
                            'Repeating the same process if trashindex is greater then the count of indexlist
                            Dim alarm As Integer = 0
                            If (Stack_Operators.Count > 0) Then
                                Select Case Stack_Operators.Peek()
                                    Case "/"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            If num1 = 0 Then
                                                MessageBox.Show("Cnt divide by 0", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 / num1)
                                            End If
                                        End If
                                    Case "*"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                MessageBox.Show("Enter a smaller input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 * num1)
                                            End If
                                        End If
                                    Case "-"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            Stack_Numbers.Push(num2 - num1)
                                        End If
                                    Case Else
                                        Stack_Operators.Push("-")
                                        alarm = 1

                                End Select
                            Else
                                Stack_Operators.Push("-")
                                alarm = 1
                            End If
                            '''''''
                            If alarm = 0 Then
                                If (Stack_Operators.Count > 0) Then
                                    Select Case Stack_Operators.Peek()
                                        Case "/"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                If num1 = 0 Then
                                                    MessageBox.Show("Cnt divide by 0", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 / num1)
                                                End If
                                            End If
                                        Case "*"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                    MessageBox.Show("Enter a smaller input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 * num1)
                                                End If
                                            End If
                                        Case "-"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                Stack_Numbers.Push(num2 - num1)
                                            End If
                                        Case Else
                                            Stack_Operators.Push("-")
                                            alarm = 1
                                    End Select
                                Else
                                    Stack_Operators.Push("-")
                                    alarm = 1
                                End If
                            End If

                            ''''''''
                            If alarm = 0 Then
                                If (Stack_Operators.Count > 0) Then
                                    Select Case Stack_Operators.Peek()
                                        Case "/"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                If num1 = 0 Then
                                                    MessageBox.Show("Cnt divide by 0", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 / num1)
                                                End If
                                                Stack_Operators.Pop()
                                                Stack_Operators.Push("-")
                                            End If
                                        Case "*"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                    MessageBox.Show("Enter a smaller input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 * num1)
                                                End If
                                                Stack_Operators.Pop()
                                                Stack_Operators.Push("-")
                                            End If
                                        Case "-"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                Stack_Numbers.Push(num2 - num1)
                                                Stack_Operators.Push("-")
                                            End If
                                        Case Else
                                            Stack_Operators.Push("-")

                                    End Select
                                Else
                                    Stack_Operators.Push("-")
                                End If
                            End If
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        'the case of "+" is also similar to that of other operators, only need to check the stack for four peak variables, therefore using the loop
                    Case "+"
                        Dim alarm As Integer = 0
                        For w = 0 To 2
                            'using alarm in the similar way as before
                            If alarm = 0 Then
                                If (Stack_Operators.Count > 0) Then
                                    Select Case Stack_Operators.Peek()
                                        Case "/"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input16", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                If num1 = 0 Then
                                                    MessageBox.Show("Cnt divide by 0", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 / num1)
                                                End If
                                            End If
                                        Case "*"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input17", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                    MessageBox.Show("Enter a smaller input", "ERROR")
                                                    RichTextBox1.Text = ""
                                                    Return False

                                                    Exit For
                                                    Stop
                                                Else
                                                    Stack_Numbers.Push(num2 * num1)
                                                End If
                                            End If
                                        Case "-"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input18", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                Stack_Numbers.Push(num2 - num1)
                                            End If
                                        Case "+"
                                            If Stack_Numbers.Count() < 2 Then
                                                MessageBox.Show("Wrong Input19", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Dim num1 As Decimal = Stack_Numbers.Pop()
                                                Dim num2 As Decimal = Stack_Numbers.Pop()
                                                Stack_Operators.Pop()
                                                Stack_Numbers.Push(num2 + num1)
                                            End If
                                        Case Else
                                            Stack_Operators.Push("+")
                                            alarm = 1
                                    End Select
                                Else
                                    Stack_Operators.Push("+")
                                    alarm = 1
                                End If
                            End If
                        Next
                        ''''''
                        If alarm = 0 Then
                            'for the last possibel time, if any operator is present is present, push the result and push the "+" after popping previous operator and two operands
                            If (Stack_Operators.Count > 0) Then
                                Select Case Stack_Operators.Peek()
                                    Case "/"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            If num1 = 0 Then
                                                MessageBox.Show("Cnt divide by 0", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 / num1)
                                            End If
                                            Stack_Operators.Push("+")
                                        End If
                                    Case "*"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                MessageBox.Show("Enter a smaller input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 * num1)
                                            End If
                                            Stack_Operators.Push("+")
                                        End If
                                    Case "-"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            Stack_Numbers.Push(num2 - num1)
                                            Stack_Operators.Push("+")
                                        End If
                                    Case "+"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            Stack_Numbers.Push(num2 + num1)
                                            Stack_Operators.Push("+")
                                        End If
                                    Case Else
                                        Stack_Operators.Push("+")
                                End Select
                            Else
                                Stack_Operators.Push("+")
                            End If
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Case ")"
                        'Till "(" is obtained or end of stack achieved, pop operator, two operands and push in the result
                        While Stack_Operators.Count > 0
                            If Stack_Operators.Peek() <> "(" Then
                                Select Case Stack_Operators.Peek()
                                    Case "/"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            If num1 = 0 Then
                                                MessageBox.Show("Cnt divide by 0", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 / num1)
                                            End If
                                        End If
                                    Case "*"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                                MessageBox.Show("Enter a smaller input", "ERROR")
                                                RichTextBox1.Text = ""
                                                Return False

                                                Exit For
                                                Stop
                                            Else
                                                Stack_Numbers.Push(num2 * num1)
                                            End If
                                        End If
                                    Case "+"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            Stack_Numbers.Push(num2 + num1)
                                        End If
                                    Case "-"
                                        If Stack_Numbers.Count() < 2 Then
                                            MessageBox.Show("Wrong Input", "ERROR")
                                            RichTextBox1.Text = ""
                                            Return False

                                            Exit For
                                            Stop
                                        Else
                                            Dim num1 As Decimal = Stack_Numbers.Pop()
                                            Dim num2 As Decimal = Stack_Numbers.Pop()
                                            Stack_Operators.Pop()
                                            Stack_Numbers.Push(num2 - num1)
                                        End If
                                    Case Else
                                        MessageBox.Show("Wrong Input", "ERROR")
                                        RichTextBox1.Text = ""
                                        Return False

                                        Exit For
                                        Stop
                                End Select
                            Else
                                Exit While
                            End If
                        End While
                        'After while, if peek is "(", it means bracket sequence was correct, and pop the peek
                        If Stack_Operators.Count > 0 Then
                            If Stack_Operators.Peek() = "(" Then
                                Stack_Operators.Pop()
                            Else
                                MessageBox.Show("Wrong Input", "ERROR")
                                RichTextBox1.Text = ""
                                Return False

                                Exit For
                                Stop
                            End If
                        Else
                            MessageBox.Show("Wrong Input", "ERROR")
                            RichTextBox1.Text = ""
                            Return False

                            Exit For
                            Stop
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End Select
                TrashChar = name(i)
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'After one full iteration over name, calculate for the remaining operators and numbers in the stack
            'do so till there is no operator left in the stack
            While Stack_Operators.Count > 0
                If Stack_Numbers.Count < 2 Then
                    MessageBox.Show("Wrong Input", "ERROR")
                    RichTextBox1.Text = ""
                    Return False

                    Exit While
                    Stop
                Else
                    Select Case Stack_Operators.Peek()
                        Case "/"
                            Dim num1 As Decimal = Stack_Numbers.Pop()
                            Dim num2 As Decimal = Stack_Numbers.Pop()
                            Stack_Operators.Pop()
                            If num1 = 0 Then
                                MessageBox.Show("Cnt divide by 0", "ERROR")
                                RichTextBox1.Text = ""
                                Return False
                                Exit While
                                Stop
                            Else
                                Stack_Numbers.Push(num2 / num1)
                            End If
                        Case "*"
                            Dim num1 As Decimal = Stack_Numbers.Pop()
                            Dim num2 As Decimal = Stack_Numbers.Pop()
                            Stack_Operators.Pop()
                            If CDec(num1) > 999999999999 Or CDec(num2) > 999999999999 Then
                                MessageBox.Show("Enter a smaller input", "ERROR")
                                RichTextBox1.Text = ""
                                Return False
                                Exit While
                                Stop
                            Else
                                Stack_Numbers.Push(num2 * num1)
                            End If
                        Case "+"
                            Dim num1 As Decimal = Stack_Numbers.Pop()
                            Dim num2 As Decimal = Stack_Numbers.Pop()
                            Stack_Operators.Pop()
                            Stack_Numbers.Push(num2 + num1)
                        Case "-"
                            Dim num1 As Decimal = Stack_Numbers.Pop()
                            Dim num2 As Decimal = Stack_Numbers.Pop()
                            Stack_Operators.Pop()
                            Stack_Numbers.Push(num2 - num1)
                    End Select
                End If
            End While
            'however having extra "(" or any other extra operators in stack can cause an error
            If Stack_Operators.Count > 0 Then
                MessageBox.Show("Wrong input", "Error")
                RichTextBox1.Text = ""
                Return False
                Stop
            End If

            'having extra numbers can also cause an error
            If Stack_Numbers.Count > 1 Then
                MessageBox.Show("Wrong input", "Error")
                RichTextBox1.Text = ""
                Return False
                Stop
            ElseIf Stack_Numbers.Count = 1 Then
                'If only one number left, then print it as the result
                RichTextBox2.Text = RichTextBox2.Text & "Result : " & CStr(Stack_Numbers.Peek())
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            RichTextBox2.Text = ""
            RichTextBox1.Text = ""
            Return False
        End Try
End Function
End Class