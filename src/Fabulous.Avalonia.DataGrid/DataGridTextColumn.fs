namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Data
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabDataGridTextColumn =
    inherit IFabDataGridColumn

module DataGridTextColumn =
    let WidgetKey = Widgets.register<DataGridTextColumn>()

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.FontStretchProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality DataGridTextColumn.ForegroundProperty

[<AutoOpen>]
module DataGridTextColumnBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        static member DataGridTextColumn<'msg>(header: string, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                DataGridColumn.HeaderString.WithValue(header),
                DataGridBoundColumn.Binding.WithValue(binding)
            )

        /// <summary>Creates a DataGridTextColumn widget.</summary>
        static member DataGridTextColumn(header: WidgetBuilder<'msg, #IFabControl>, binding: IBinding) =
            WidgetBuilder<'msg, IFabDataGridTextColumn>(
                DataGridTextColumn.WidgetKey,
                AttributesBundle(
                    StackList.one(DataGridBoundColumn.Binding.WithValue(binding)),
                    ValueSome [| DataGridColumn.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )


[<Extension>]
type DataGridTextColumnModifiers =
    /// <summary>Link a ViewRef to access the direct DataGridTextColumn control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: ViewRef<DataGridTextColumn>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: FontFamily) =
        this.AddScalar(DataGridTextColumn.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: float) =
        this.AddScalar(DataGridTextColumn.FontSize.WithValue(value))

    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: FontStyle) =
        this.AddScalar(DataGridTextColumn.FontStyle.WithValue(value))

    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: FontWeight) =
        this.AddScalar(DataGridTextColumn.FontWeight.WithValue(value))

    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: FontStretch) =
        this.AddScalar(DataGridTextColumn.FontStretch.WithValue(value))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: IBrush) =
        this.AddScalar(DataGridTextColumn.Foreground.WithValue(value))

    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, IFabDataGridTextColumn>, value: string) =
        this.AddScalar(TextElement.Foreground.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))
