open System


// Ôóíêöèÿ äëÿ ââîäà íîìåðà çàäàíèÿ
let rec CH prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match input with
    | _ when input.Length < 1 ->
        printfn "Ââåäèòå  îò 1 äî 3"
        CH prompt
    | _ when input.Length > 3 ->
        printfn "Ââåäèòå  îò 1 äî 3"
        CH prompt
    | _ -> int input





// Number 1

// Ôóíêöèÿ äëÿ ââîäà ñèìâîëà
let rec CHARinput prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match input with
    | null | "" ->
        printfn "Ââåäèòå ñèìâîë çíà÷åíèå íå ìîæåò áûòü ïóñòûì"
        CHARinput prompt
    | _ when input.Length > 1 ->
        printfn "Ââåäèòå òîëüêî îäèí ñèìâîë"
        CHARinput prompt
    | _ -> char input



// Ôóíêöèÿ äëÿ ââîäà äëèíû ñïèñêà
let rec INTinput prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match input with
    | _ when input.Length < 1 ->
        printfn "Ââåäèòå ïîëîæèòåëüíî ÷èñëî"
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

// Ôóíêöèÿ äëÿ íàõîæäåíèÿ ñóììû öèôð íàòóðàëüíîãî ÷èñëà
let rec sumOfDigits n =
    if n = 0 then 0
    else (n % 10) + sumOfDigits (n / 10)




// Number 3

// Îïðåäåëåíèå òèïà äëÿ êîìïëåêñíîãî ÷èñëà
type Complex = { Re: float; Im: float }

// Ôóíêöèÿ ñëîæåíèÿ äâóõ êîìïëåêñíûõ ÷èñåë
let add (a: Complex) (b: Complex) =
    { Re = a.Re + b.Re; Im = a.Im + b.Im }

// Ôóíêöèÿ âû÷èòàíèÿ äâóõ êîìïëåêñíûõ ÷èñåë
let subtract (a: Complex) (b: Complex) =
    { Re = a.Re - b.Re; Im = a.Im - b.Im }

// Ôóíêöèÿ óìíîæåíèÿ äâóõ êîìïëåêñíûõ ÷èñåë
let multiply (a: Complex) (b: Complex) =
    { Re = a.Re * b.Re - a.Im * b.Im; Im = a.Re * b.Im + a.Im * b.Re }

// Ôóíêöèÿ äåëåíèÿ äâóõ êîìïëåêñíûõ ÷èñåë
let divide (a: Complex) (b: Complex) =
    
    let denominator = b.Re * b.Re + b.Im * b.Im
    if denominator = 0.0 then failwith "Äåëåíèå íà íîëü" 
    else
        { Re = (a.Re * b.Re + a.Im * b.Im) / denominator;
          Im = (a.Im * b.Re - a.Re * b.Im) / denominator }

// Ôóíêöèÿ âîçâåäåíèÿ êîìïëåêñíîãî ÷èñëà â öåëî÷èñëåííóþ ñòåïåíü
let rec power (a: Complex) (n: int) =
    if n = 0 then { Re = 1.0; Im = 0.0 }
    elif n = 1 then a
    else multiply a (power a (n - 1))
    





// Îñíîâíàÿ ïðîãðàììà
let run1 () =
    let char1 = CHARinput "Ââåäèòå ïåðâûé ñèìâîë: "
    let char2 = CHARinput "Ââåäèòå âòîðîé ñèìâîë: "
    let length = INTinput "Ââåäèòå äëèíó ñïèñêà: "
    
    
    let resultList = createAlternatingList char1 char2 length
    printfn "Ñïèñîê: %A" resultList

    

let run2 () = 
    let sum = INTinput "Ââåäèòå íàòóðàëüíîå ÷èñëî: "

    let resultSum = sumOfDigits sum
    printfn "Ñóììà öèôð: %d" resultSum


let run3 () = 
   let a = { Re = 3.0; Im = 2.0 }
   let b = { Re = 1.0; Im = -4.0 }

   let sum = add a b
   let diff = subtract a b
   let prod = multiply a b
   let quot = divide a b
   let pow = power a 3

   printfn "Ñëîæåíèå: %A" sum
   printfn "Âû÷èòàíèå: %A" diff
   printfn "Óìíîæåíèå: %A" prod
   printfn "Äåëåíèå: %A" quot
   printfn "Âîçâåäåíèå â ñòåïåíü: %A" pow


let mainrun () =
    let choose = CH "Ââåäèòå íîìåð çàäàíèÿ äëÿ ïðîâåðêè"

    if choose = 1 then run1()
    if choose = 2 then run2()
    if choose = 3 then run3()

    
        
mainrun()


(*// Òåñòû äëÿ çàäàíèÿ 1
let runTest1 () =
    let resultList1 = createAlternatingList 'A' 'B' 5
    printfn "Òåñò 1.1 (Îæèäàåòñÿ: ['A'; 'B'; 'A'; 'B'; 'A']): %A" resultList1

    let resultList2 = createAlternatingList 'X' 'Y' 6
    printfn "Òåñò 1.2 (Îæèäàåòñÿ: ['X'; 'Y'; 'X'; 'Y'; 'X'; 'Y']): %A" resultList2

// Òåñòû äëÿ çàäàíèÿ 2
let runTest2 () =
    let sum1 = sumOfDigits 12345
    printfn "Òåñò 2.1 (Îæèäàåòñÿ: 15): %d" sum1

    let sum2 = sumOfDigits 987
    printfn "Òåñò 2.2 (Îæèäàåòñÿ: 24): %d" sum2

// Òåñòû äëÿ çàäàíèÿ 3
let runTest3 () =
    let a = { Re = 3.0; Im = 2.0 }
    let b = { Re = 1.0; Im = -4.0 }

    let sum = add a b
    printfn "Òåñò 3.1 (Ñëîæåíèå, Îæèäàåòñÿ: { Re = 4.0; Im = -2.0 }): %A" sum

    let prod = multiply a b
    printfn "Òåñò 3.2 (Óìíîæåíèå, Îæèäàåòñÿ: { Re = 11.0; Im = -10.0 }): %A" prod

// Îñíîâíàÿ ôóíêöèÿ çàïóñêà òåñòîâ
let runTests () =
    printfn "Çàïóñê òåñòîâ äëÿ çàäàíèÿ 1..."
    runTest1()
    
    printfn "Çàïóñê òåñòîâ äëÿ çàäàíèÿ 2..."
    runTest2()

    printfn "Çàïóñê òåñòîâ äëÿ çàäàíèÿ 3..."
    runTest3()

// Çàïóñê òåñòîâ
runTests()
*)
