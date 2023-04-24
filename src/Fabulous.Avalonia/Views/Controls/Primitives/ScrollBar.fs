namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Fabulous

type IFabScrollBar =
    inherit IFabRangeBase

module ScrollBar =
    let WidgetKey = Widgets.register<ScrollBar>()

    let ViewportSize =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.ViewportSizeProperty

    let Visibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.VisibilityProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.OrientationProperty

    let AllowAutoHide =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.AllowAutoHideProperty

    let HideDelay =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.HideDelayProperty

    let ShowDelay =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.ShowDelayProperty

    let Scroll =
        Attributes.defineEvent "ScrollBar_Scroll" (fun target -> (target :?> ScrollBar).Scroll)

[<AutoOpen>]
module ScrollBarBuilders =
    type Fabulous.Avalonia.View with

        static member inline ScrollBar(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
            WidgetBuilder<'msg, IFabScrollBar>(
                ScrollBar.WidgetKey,
                RangeBase.MinimumMaximum.WithValue(min, max),
                RangeBase.ValueChanged.WithValue(ValueEventData.create value (fun args -> onValueChanged args |> box))
            )

[<Extension>]
type ScrollBarModifiers =

    [<Extension>]
    static member inline viewportSize(this: WidgetBuilder<'msg, #IFabScrollBar>, value: float) =
        this.AddScalar(ScrollBar.ViewportSize.WithValue(value))

    [<Extension>]
    static member inline visibility(this: WidgetBuilder<'msg, #IFabScrollBar>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollBar.Visibility.WithValue(value))

    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabScrollBar>, value: Orientation) =
        this.AddScalar(ScrollBar.Orientation.WithValue(value))

    [<Extension>]
    static member inline allowAutoHide(this: WidgetBuilder<'msg, #IFabScrollBar>, value: bool) =
        this.AddScalar(ScrollBar.AllowAutoHide.WithValue(value))

    [<Extension>]
    static member inline hideDelay(this: WidgetBuilder<'msg, #IFabScrollBar>, value: TimeSpan) =
        this.AddScalar(ScrollBar.HideDelay.WithValue(value))

    [<Extension>]
    static member inline showDelay(this: WidgetBuilder<'msg, #IFabScrollBar>, value: TimeSpan) =
        this.AddScalar(ScrollBar.ShowDelay.WithValue(value))

    [<Extension>]
    static member inline onScroll(this: WidgetBuilder<'msg, #IFabScrollBar>, onScroll: ScrollEventArgs -> 'msg) =
        this.AddScalar(ScrollBar.Scroll.WithValue(fun args -> onScroll args |> box))

    /// <summary>Link a ViewRef to access the direct ScrollBar control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabScrollBar>, value: ViewRef<ScrollBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
