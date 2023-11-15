namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabGradientStop =
    inherit IFabElement

module GradientStop =

    let WidgetKey = Widgets.register<GradientStop>()

    let Color = Attributes.defineAvaloniaPropertyWithEquality GradientStop.ColorProperty

    let Offset =
        Attributes.defineAvaloniaPropertyWithEquality GradientStop.OffsetProperty

[<AutoOpen>]
module GradientStopBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a GradientStop widget.</summary>
        /// <param name="color">The color of the gradient stop.</param>
        /// <param name="offset">The offset of the gradient stop.</param>
        static member inline GradientStop(color: Color, offset: float) =
            WidgetBuilder<'msg, IFabGradientStop>(GradientStop.WidgetKey, GradientStop.Color.WithValue(color), GradientStop.Offset.WithValue(offset))

        /// <summary>Creates a GradientStop widget.</summary>
        /// <param name="color">The color of the gradient stop.</param>
        /// <param name="offset">The offset of the gradient stop.</param>
        static member inline GradientStop(color: string, offset: float) =
            WidgetBuilder<'msg, IFabGradientStop>(
                GradientStop.WidgetKey,
                GradientStop.Color.WithValue(Color.Parse(color)),
                GradientStop.Offset.WithValue(offset)
            )

type GradientStopBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGradientStop>
        (
            _: CollectionBuilder<'msg, 'marker, IFabGradientStop>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabGradientStop>
        (
            _: CollectionBuilder<'msg, 'marker, IFabGradientStop>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
