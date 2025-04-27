open System

// Функция для проверки ввода целого числа
let rec inputInt (prompt: string) =
    printf "%s" prompt
    match Int32.TryParse(Console.ReadLine()) with
    | true, number when number >= 0 -> number
    | _ -> 
        printfn "Ошибка: введите целое неотрицательное число."
        inputInt prompt

// Функция для проверки ввода цифры (0-9)
let rec inputDigit (prompt: string) =
    printf "%s" prompt
    match Int32.TryParse(Console.ReadLine()) with
    | true, d when d >= 0 && d <= 9 -> d
    | _ -> 
        printfn "Ошибка: введите цифру от 0 до 9."
        inputDigit prompt

// Функция для генерации случайного списка чисел
let generateRandomList count min max =
    let rnd = Random()
    List.init count (fun _ -> rnd.Next(min, max + 1))

// Функция для ввода списка с выбором способа
let inputListWithChoice listName =
    printfn $"\nСпособ заполнения списка {listName}:"
    printfn "1 - Ввести числа вручную"
    printfn "2 - Сгенерировать случайные числа"
    printf "Ваш выбор: "
    
    match Console.ReadLine() with
    | "1" ->
        printfn "Введите числа через пробел:"
        Console.ReadLine().Split(' ')
        |> Array.map (fun s -> 
            match Int32.TryParse(s) with
            | true, num -> num
            | false, _ -> 
                printfn $"Неверный формат числа: '{s}'. Будет использовано 0."
                0)
        |> List.ofArray
    | "2" ->
        let count = inputInt "Введите количество элементов: "
        let min = inputInt "Введите минимальное значение: "
        let max = inputInt "Введите максимальное значение: "
        generateRandomList count min max
    | _ ->
        printfn "Неверный выбор, будет использован пустой список."
        []

// Задание 1: Получить список из последних цифр чисел
let task1 () =
    let numbers = inputListWithChoice "для задания 1"
    printfn "\nИсходный список чисел: %A" numbers
    
    let lastDigits = numbers |> List.map (fun x -> abs x % 10)
    printfn "Список последних цифр: %A" lastDigits

// Задание 2: Найти сумму элементов, оканчивающихся на заданную цифру
let task2 () =
    let numbers = inputListWithChoice "для задания 2"
    printfn "\nИсходный список чисел: %A" numbers
    
    let targetDigit = inputDigit "Введите цифру для фильтрации (0-9): "
    
    let sum = 
        numbers 
        |> List.fold (fun acc x -> 
            if abs x % 10 = targetDigit then acc + x 
            else acc) 0
    
    printfn "Сумма чисел, оканчивающихся на %d: %d" targetDigit sum

// Основное меню
let main () =
    let rec loop () =
        printfn "\nВыберите задание:"
        printfn "1 - Получить последние цифры чисел (List.map)"
        printfn "2 - Найти сумму чисел по последней цифре (List.fold)"
        printfn "0 - Выход"
        printf "Ваш выбор: "
        
        match Console.ReadLine() with
        | "1" -> task1 ()
        | "2" -> task2 ()
        | "0" -> printfn "Программа завершена."
        | _ -> printfn "Неверный ввод! Попробуйте снова."
        
        if not (Console.ReadLine() = "0") then loop ()
    
    printfn "Лабораторная работа: обработка списков в F#"
    loop ()

// Запуск программы
main ()
