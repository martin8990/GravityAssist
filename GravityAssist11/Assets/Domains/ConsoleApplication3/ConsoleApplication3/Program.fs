open System
open System.Collections.Generic
let RemoveDupes(option : list<string>) =
       
    HashSet<string> option
    |>List.ofSeq
let lowercase (x : string) = x.ToLower()


let GetStartingWith (options : list<string>,input : string) = 
    options|>List.map(fun y -> lowercase y)|> List.filter(fun y -> y.StartsWith(input))

let Contained(ops : list<string>,input : string) =
    ops|>List.map(fun y -> lowercase y)|>List.filter(fun y -> y.Contains(input)) 

let Options = ["TWo";"TWO";"TWO"]|>RemoveDupes

let NOptions = Options|>List.length 
let maxShownCount = 10


let GetSw (options : list<string>,input : string, max : int) =
    let A = List<string>()
    for i in [0..options.Length-1] do
        if (A.Count < max && options.[i]|>lowercase|>fun y -> y.StartsWith(input)) then
           A.Add(options.[i])
    
    if A.Count=0 then
        for i in [0..options.Length-1] do
            if (A.Count < max && options.[i]|>lowercase|>fun y -> y.Contains(input)) then
                A.Add(options.[i])
    A
              

let input = "TW"|>lowercase
let a = GetSw(Options,input,10) 
Console.WriteLine(a.[0])

Console.ReadLine() |> ignore