namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Data
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabDataGridCheckBoxColumn =
    inherit IFabDataGridColumn

module DataGridCheckBoxColumn =
    let WidgetKey = Widgets.register<DataGridCheckBoxColumn>()

[<AutoOpen>]
module DataGridCheckBoxColumnBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        static member DataGridCheckBoxColumn<'msg>(header: string, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridCheckBoxColumn widget.</summary>
        static member DataGridCheckBoxColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>(
                DataGridCheckBoxColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(binding)),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )


[<Extension>]
type DataGridCheckBoxColumnModifiers =
    /// <summary>Link a ViewRef to access the direct DataGridCheckBoxColumn control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDataGridCheckBoxColumn>, value: ViewRef<DataGridCheckBoxColumn>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
