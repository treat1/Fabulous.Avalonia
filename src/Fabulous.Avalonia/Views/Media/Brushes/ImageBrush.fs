namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

type IFabImageBrush =
    inherit IFabTileBrush

module ImageBrush =
    let WidgetKey = Widgets.register<ImageBrush>()

    let Source = Attributes.defineAvaloniaPropertyWithEquality ImageBrush.SourceProperty

[<AutoOpen>]
module ImageBrushBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ImageBrush widget.</summary>
        /// <param name="source">The image source.</param>
        static member ImageBrush(source: Bitmap) =
            WidgetBuilder<'msg, IFabImageBrush>(ImageBrush.WidgetKey, ImageBrush.Source.WithValue(source))

[<Extension>]
type ImageBrushModifiers =
    /// <summary>Link a ViewRef to access the direct ImageBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabImageBrush>, value: ViewRef<ImageBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
