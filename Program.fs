// Read a string and write the output in Synology hex format
open System

let charToAscii (c: char) = c |> int

let intToHex (i:int) = i.ToString("x2")

let charToHex = charToAscii >> intToHex

let splitString (c:char) (s:string) = s.Split(c, StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries)
                                      |> Array.toList
    
[<EntryPoint>]
let main argv =
    
    if argv.Length < 1 then
        Console.WriteLine("You must provide a string to hexify")
        Environment.Exit(16)

    let hex = String.Concat(argv[0] |> splitString '.'
                        |> List.map (fun s -> String.Concat(s.Length
                                                            |> intToHex,
                                                            String.Concat(s.ToCharArray()
                                                                          |> Array.toList
                                                                          |> List.map charToHex))))
    
    Console.WriteLine(hex)
    
    Environment.Exit(0)    
    
    
    0 // return an integer exit code