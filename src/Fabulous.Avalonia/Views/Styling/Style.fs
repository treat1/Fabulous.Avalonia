namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

module Style =

    let WidgetKey = Widgets.register<Style>()

    let Animations =
        Attributes.defineListWidgetCollection "Style_Animations" (fun target -> (target :?> Style).Animations :> IList<_>)

[<AutoOpen>]
module StyleBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates an Animations widget.</summary>
        static member Animations() =
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations)

type StyleModifiers =
    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animation(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabAnimation>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.StylesWidget) {
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations) { value }
        }

    /// <summary>Sets the Animations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Animation value.</param>
    [<Extension>]
    static member inline animations(this: WidgetBuilder<'msg, #IFabStyledElement>, value: WidgetBuilder<'msg, IFabStyle>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.StylesWidget) { value }

    /// <summary>Link a ViewRef to access the direct Style control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabStyle>, value: ViewRef<Style>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type StyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: CollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: CollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
