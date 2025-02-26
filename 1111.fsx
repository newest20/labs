open System


// ������� ��� ����� ������ �������
let rec CH prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match input with
    | _ when input.Length < 1 ->
        printfn "�������  �� 1 �� 3"
        CH prompt
    | _ when input.Length > 3 ->
        printfn "�������  �� 1 �� 3"
        CH prompt
    | _ -> int input





// Number 1

// ������� ��� ����� �������
let rec CHARinput prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match input with
    | null | "" ->
        printfn "������� ������ �������� �� ����� ���� ������"
        CHARinput prompt
    | _ when input.Length > 1 ->
        printfn "������� ������ ���� ������"
        CHARinput prompt
    | _ -> char input



// ������� ��� ����� ����� ������
let rec INTinput prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match input with
    | _ when input.Length < 1 ->
        printfn "������� ������������ �����"
        INTinput prompt
    | _ -> int input



let rec generateList char1 char2 length index acc =
    if index >= length then List.rev acc
    else
        let nextChar = if index % 2 = 0 then char1 else char2
        generateList char1 char2 length (index + 1) (nextChar :: acc)

let createAlternatingList (char1: char) (char2: char) length =
    generateList char1 char2 length 0 []





// Number 2

// ������� ��� ���������� ����� ���� ������������ �����
let rec sumOfDigits n =
    if n = 0 then 0
    else (n % 10) + sumOfDigits (n / 10)




// Number 3

// ����������� ���� ��� ������������ �����
type Complex = { Re: float; Im: float }

// ������� �������� ���� ����������� �����
let add (a: Complex) (b: Complex) =
    { Re = a.Re + b.Re; Im = a.Im + b.Im }

// ������� ��������� ���� ����������� �����
let subtract (a: Complex) (b: Complex) =
    { Re = a.Re - b.Re; Im = a.Im - b.Im }

// ������� ��������� ���� ����������� �����
let multiply (a: Complex) (b: Complex) =
    { Re = a.Re * b.Re - a.Im * b.Im; Im = a.Re * b.Im + a.Im * b.Re }

// ������� ������� ���� ����������� �����
let divide (a: Complex) (b: Complex) =
    
    let denominator = b.Re * b.Re + b.Im * b.Im
    if denominator = 0.0 then failwith "������� �� ����" 
    else
        { Re = (a.Re * b.Re + a.Im * b.Im) / denominator;
          Im = (a.Im * b.Re - a.Re * b.Im) / denominator }

// ������� ���������� ������������ ����� � ������������� �������
let rec power (a: Complex) (n: int) =
    if n = 0 then { Re = 1.0; Im = 0.0 }
    elif n = 1 then a
    else multiply a (power a (n - 1))
    





// �������� ���������
let run1 () =
    let char1 = CHARinput "������� ������ ������: "
    let char2 = CHARinput "������� ������ ������: "
    let length = INTinput "������� ����� ������: "
    
    
    let resultList = createAlternatingList char1 char2 length
    printfn "������: %A" resultList

    

let run2 () = 
    let sum = INTinput "������� ����������� �����: "

    let resultSum = sumOfDigits sum
    printfn "����� ����: %d" resultSum


let run3 () = 
   let a = { Re = 3.0; Im = 2.0 }
   let b = { Re = 1.0; Im = -4.0 }

   let sum = add a b
   let diff = subtract a b
   let prod = multiply a b
   let quot = divide a b
   let pow = power a 3

   printfn "��������: %A" sum
   printfn "���������: %A" diff
   printfn "���������: %A" prod
   printfn "�������: %A" quot
   printfn "���������� � �������: %A" pow


let mainrun () =
    let choose = CH "������� ����� ������� ��� ��������"

    if choose = 1 then run1()
    if choose = 2 then run2()
    if choose = 3 then run3()

    
        
mainrun()


(*// ����� ��� ������� 1
let runTest1 () =
    let resultList1 = createAlternatingList 'A' 'B' 5
    printfn "���� 1.1 (���������: ['A'; 'B'; 'A'; 'B'; 'A']): %A" resultList1

    let resultList2 = createAlternatingList 'X' 'Y' 6
    printfn "���� 1.2 (���������: ['X'; 'Y'; 'X'; 'Y'; 'X'; 'Y']): %A" resultList2

// ����� ��� ������� 2
let runTest2 () =
    let sum1 = sumOfDigits 12345
    printfn "���� 2.1 (���������: 15): %d" sum1

    let sum2 = sumOfDigits 987
    printfn "���� 2.2 (���������: 24): %d" sum2

// ����� ��� ������� 3
let runTest3 () =
    let a = { Re = 3.0; Im = 2.0 }
    let b = { Re = 1.0; Im = -4.0 }

    let sum = add a b
    printfn "���� 3.1 (��������, ���������: { Re = 4.0; Im = -2.0 }): %A" sum

    let prod = multiply a b
    printfn "���� 3.2 (���������, ���������: { Re = 11.0; Im = -10.0 }): %A" prod

// �������� ������� ������� ������
let runTests () =
    printfn "������ ������ ��� ������� 1..."
    runTest1()
    
    printfn "������ ������ ��� ������� 2..."
    runTest2()

    printfn "������ ������ ��� ������� 3..."
    runTest3()

// ������ ������
runTests()
*)