% Главное меню
start :-
    write('Добро пожаловать в программу! Выберите задачу:'), nl,
    write('1. Определить, в каком из двух чисел больше цифр'), nl,
    write('2. Найти сумму элементов списка, оканчивающихся на заданную цифру'), nl,
    write('3. Найти объединение множеств'), nl,
    write('4. Логическая задача о подразделениях фирмы'), nl,
    write('0. Выход'), nl,
    read(Choice),
    (Choice = 0 -> halt ; run_task(Choice)).

% Обработчик выбора
run_task(1) :-
    nl,
    write('Введите первое число: '), read(N1),
    write('Введите второе число: '), read(N2),
    (   integer(N1), integer(N2)
    ->  count_digits(abs(N1), Len1),
        count_digits(abs(N2), Len2),
        compare_lengths(Len1, Len2, N1, N2),
        start
    ;   write('Ошибка: введите целые числа!'), nl, nl,
        run_task(1)
    ).

run_task(2) :-
    write('Введите список целых чисел: '), read(List),
    write('Введите цифру для фильтрации (0-9): '), read(Digit),
    (   between(0, 9, Digit)
    ->  sum_ending_with(List, Digit, Sum),
        format('Сумма элементов, оканчивающихся на ~w: ~w~n', [Digit, Sum]),
        start
    ;   write('Ошибка: цифра должна быть от 0 до 9!'), nl, nl,
        run_task(2)
    ).

run_task(3) :-
    write('Введите первое множество (список без повторений): '), read(Set1),
    write('Введите второе множество (список без повторений): '), read(Set2),
    union_sets(Set1, Set2, Union),
    write('Объединение множеств: '), write(Union), nl,
    start.

run_task(4) :-
    write('Решение логической задачи о подразделениях фирмы:'), nl, nl,
    solve_firm_problem,
    nl, start.

% Задача 1: Определить, в каком числе больше цифр

% Подсчет цифр в числе
count_digits(0, 1) :- !.
count_digits(N, Len) :-
    N > 0,
    count_digits(N, 0, Len).

count_digits(0, Acc, Acc) :- !.
count_digits(N, Acc, Len) :-
    N > 0,
    NewAcc is Acc + 1,
    NewN is N // 10,
    count_digits(NewN, NewAcc, Len).

% Сравнение длин чисел
compare_lengths(Len1, Len2, N1, N2) :-
    (   Len1 > Len2
    ->  format('В числе ~w больше цифр (~w > ~w)~n', [N1, Len1, Len2])
    ;   Len2 > Len1
    ->  format('В числе ~w больше цифр (~w > ~w)~n', [N2, Len2, Len1])
    ;   format('Оба числа имеют одинаковое количество цифр (~w)~n', [Len1])
    ).

% Задача 2: Сумма элементов, оканчивающихся на заданную цифру

sum_ending_with(List, Digit, Sum) :-
    include(ends_with(Digit), List, Filtered),
    sum_list(Filtered, Sum).

% Проверка, что число оканчивается на заданную цифру
ends_with(Digit, Number) :-
    abs(Number) mod 10 =:= Digit.

% Задача 3: Объединение множеств

union_sets(Set1, Set2, Union) :-
    append(Set1, Set2, Combined),
    remove_duplicates(Combined, Union).

% Удаление дубликатов из списка
remove_duplicates([], []).
remove_duplicates([H|T], Result) :-
    member(H, T),
    remove_duplicates(T, Result).
remove_duplicates([H|T], [H|Result]) :-
    \+ member(H, T),
    remove_duplicates(T, Result).

% Задача 4: Логическая задача о подразделениях фирмы

solve_firm_problem :-
    % Возможные варианты максимальной прибыли (1 - есть, 0 - нет)
    member([A, B, C], [[0,0,0], [0,0,1], [0,1,0], [0,1,1], [1,0,0], [1,0,1], [1,1,0], [1,1,1]]),
    
    % Проверяем предположения
    assumption1(A, B, C, Ass1),
    assumption2(A, C, Ass2),
    assumption3(B, C, Ass3),
    
    % Одно предположение ложно, два истинны
    count_false([Ass1, Ass2, Ass3], 1),
    
    % Вывод результата
    format('Подразделение A: ~w~n', [A]),
    format('Подразделение B: ~w~n', [B]),
    format('Подразделение C: ~w~n', [C]),
    nl,
    write('Где 1 - получило максимальную прибыль, 0 - не получило'), nl.

% Подсчет ложных утверждений
count_false([], 0).
count_false([true|T], N) :-
    count_false(T, N).
count_false([false|T], N) :-
    count_false(T, N1),
    N is N1 + 1.

% Предположение 1: A получит прибыль только когда B и C получат
assumption1(A, B, C, Result) :-
    (A =:= 1 -> (B =:= 1, C =:= 1) ; true) -> Result = true ; Result = false.
% Предположение 2: Либо A и C получат одновременно, либо одновременно не получат
assumption2(A, C, Result) :-
    ((A =:= C) -> Result = true ; Result = false).

% Предположение 3: Для прибыли C необходимо, чтобы B получило прибыль
assumption3(B, C, Result) :-
    (C =:= 1 -> B =:= 1 ; true) -> Result = true ; Result = false.

