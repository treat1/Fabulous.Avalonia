namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous

type IFabTopLevel =
    inherit IFabContentControl

module TopLevel =

    let TransparencyLevelHint =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyLevelHintProperty

    let TransparencyBackgroundFallbackWidget =
        Attributes.defineAvaloniaPropertyWidget TopLevel.TransparencyBackgroundFallbackProperty

    let TransparencyBackgroundFallback =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyBackgroundFallbackProperty

    let Opened =
        Attributes.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

    let BackRequested =
        Attributes.defineEvent "TopLevel_BackRequestedEvent" (fun target -> (target :?> TopLevel).BackRequested)

[<Extension>]
type TopLevelModifiers =
    [<Extension>]
    static member inline transparencyLevelHint(this: WidgetBuilder<'msg, #IFabTopLevel>, alignment: WindowTransparencyLevel) =
        this.AddScalar(TopLevel.TransparencyLevelHint.WithValue(alignment))

    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, content: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TopLevel.TransparencyBackgroundFallbackWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline transparencyBackgroundFallback(this: WidgetBuilder<'msg, #IFabTopLevel>, brush: string) =
        this.AddScalar(TopLevel.TransparencyBackgroundFallback.WithValue(brush |> Color.Parse |> ImmutableSolidColorBrush))

    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabTopLevel>, onOpened: 'msg) =
        this.AddScalar(TopLevel.Opened.WithValue(onOpened))

    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabTopLevel>, onClosed: 'msg) =
        this.AddScalar(TopLevel.Closed.WithValue(onClosed))

    [<Extension>]
    static member inline onBackRequested(this: WidgetBuilder<'msg, #IFabTopLevel>, onBackRequested: 'msg) =
        this.AddScalar(TopLevel.BackRequested.WithValue(fun _ -> onBackRequested |> box))
