﻿module Scrabble.Core.Setup

open Scrabble.Core.AI
open Scrabble.Core.HillClimbingAI
open Scrabble.Core.Types
open Scrabble.Core.UtilityFunctions

let SetupComputer() = 
    Game.Instance.ComputerPlayers |> Seq.iter (fun c -> 
        c.Provider <- //HillClimbingMoveGenerator(Game.Instance.Dictionary, 5) //random restart 5 times
                        HillClimbingMoveGenerator(Game.Instance.Dictionary) 
                        //MoveGenerator(Game.Instance.Dictionary)
        c.UtilityFunction <- MaximumScore
                            //SmartSMoves
                            //SaveCommon
                            //OnlyPlay7s
                            //OnlyPlayOver5
    )

let SetupFirstComputer() = 
    let first = Game.Instance.ComputerPlayers |> Seq.head
    
    first.Provider <- //HillClimbingMoveGenerator(Game.Instance.Dictionary, 5) //random restart 5 times
                        HillClimbingMoveGenerator(Game.Instance.Dictionary) 
                        //MoveGenerator(Game.Instance.Dictionary)
    first.UtilityFunction <- MaximumScore
                            //SmartSMoves
                            //SaveCommon
                            //OnlyPlay7s
                            //OnlyPlayOver5

let SetupSecondComputer() = 
    let second = Game.Instance.ComputerPlayers |> Seq.toList |> List.tail |> List.head
    
    second.Provider <- //HillClimbingMoveGenerator(Game.Instance.Dictionary, 3) //random restart 5 times
                        //HillClimbingMoveGenerator(Game.Instance.Dictionary) 
                        MoveGenerator(Game.Instance.Dictionary)
    second.UtilityFunction <- //MaximumScore
                            //SmartSMoves
                            //SaveCommon
                            //OnlyPlay7s
                            OnlyPlayOver5