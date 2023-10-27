namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabDataGridBoundColumn =
    inherit IFabDataGridColumn

module DataGridBoundColumn =
    let Binding =
        Attributes.definePropertyWithGetSet
            "DataGridColumn_Binding"
            (fun target ->
                let target = target :?> DataGridBoundColumn
                target.Binding)
            (fun target value ->
                let target = target :?> DataGridBoundColumn
                target.Binding <- value)
