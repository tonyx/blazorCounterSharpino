﻿
namespace SharpinoCounter
open System
open Sharpino
open Counters.Commons
open FSharpPlus
open FsToolkit.ErrorHandling
open Sharpino.Definitions
open Sharpino.Utils

module CounterContext =
    type CounterContext(state: int, counterRefs: List<Guid>) =
        let stateId = Guid.NewGuid ()

        member this.CountersReferences = counterRefs

        member this.AddCounter (counterId: Guid) = 
            result {
                do! 
                    counterRefs |> List.exists (fun x -> x = counterId)
                    |> not
                    |> Result.ofBool "counter already exists"
                return CounterContext (state, counterRefs @ [counterId]) 
            }
        member this.RemoveCounter (counterId: Guid) =
            result {
                do! 
                    counterRefs |> List.exists (fun x -> x = counterId)
                    |> Result.ofBool "counter does not exist"
                return CounterContext (state, counterRefs |> List.filter (fun x -> x <> counterId))
            }

        member this.State = state

// -------
        member this.StateId = stateId
        static member Zero = CounterContext (0, []) 
        static member StorageName = "_countercontext"
        static member Version = "_01"
        static member SnapshotsInterval = 15
        static member Lock = new Object ()
        static member Deserialize (json: Json) =
            globalSerializer.Deserialize<CounterContext> json 

        member this.Serialize =
            globalSerializer.Serialize this
