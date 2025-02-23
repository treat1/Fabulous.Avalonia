namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Animation.Easings
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabAnimation =
    inherit IFabAvaloniaObject

module Animation =

    let WidgetKey = Widgets.register<Animation>()

    let Duration =
        Attributes.defineAvaloniaPropertyWithEquality Animation.DurationProperty

    let IterationCount =
        Attributes.defineAvaloniaPropertyWithEquality Animation.IterationCountProperty

    let PlaybackDirection =
        Attributes.defineAvaloniaPropertyWithEquality Animation.PlaybackDirectionProperty

    let FillMode =
        Attributes.defineAvaloniaPropertyWithEquality Animation.FillModeProperty

    let Easing = Attributes.defineAvaloniaPropertyWithEquality Animation.EasingProperty

    let Delay = Attributes.defineAvaloniaPropertyWithEquality Animation.DelayProperty

    let DelayBetweenIterations =
        Attributes.defineAvaloniaPropertyWithEquality Animation.DelayBetweenIterationsProperty

    let SpeedRatio =
        Attributes.defineAvaloniaPropertyWithEquality Animation.SpeedRatioProperty

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "Animation_KeyFramesProperty" (fun target -> (target :?> Animation).Children)

[<AutoOpen>]
module AnimationBuilders =

    type Fabulous.Avalonia.View with

        /// <summary>Creates a Animation widget with the specified duration and keyframes.</summary>
        /// <param name="duration">The main Window of the Application.</param>
        static member Animation<'msg>(duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children, Animation.Duration.WithValue(duration))

        /// <summary>Creates a Animation widget with keyframes.</summary>
        static member Animation<'msg>() =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children)

[<Extension>]
type AnimationModifiers =
    /// <summary>Sets the IterationCount property to Infinite.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline repeatForever(this: WidgetBuilder<'msg, #IFabAnimation>) =
        this.AddScalar(Animation.IterationCount.WithValue(IterationCount.Infinite))

    /// <summary>Sets the IterationCount property to the specified value.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The number of times the animation should repeat.</param>
    [<Extension>]
    static member inline repeatCount(this: WidgetBuilder<'msg, #IFabAnimation>, value: int) =
        this.AddScalar(Animation.IterationCount.WithValue(IterationCount(uint64 value, IterationType.Many)))

    /// <summary>Sets the PlaybackDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PlaybackDirection value.</param>
    [<Extension>]
    static member inline playbackDirection(this: WidgetBuilder<'msg, #IFabAnimation>, value: PlaybackDirection) =
        this.AddScalar(Animation.PlaybackDirection.WithValue(value))

    /// <summary>Sets the FillMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FillMode value.</param>
    [<Extension>]
    static member inline fillMode(this: WidgetBuilder<'msg, #IFabAnimation>, value: FillMode) =
        this.AddScalar(Animation.FillMode.WithValue(value))

    /// <summary>Sets the Easing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Easing value.</param>
    [<Extension>]
    static member inline easing(this: WidgetBuilder<'msg, #IFabAnimation>, value: Easing) =
        this.AddScalar(Animation.Easing.WithValue(value))

    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabAnimation>, value: TimeSpan) =
        this.AddScalar(Animation.Delay.WithValue(value))

    /// <summary>Sets the DelayBetweenIterations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DelayBetweenIterations value.</param>
    [<Extension>]
    static member inline delayBetweenIterations(this: WidgetBuilder<'msg, #IFabAnimation>, value: TimeSpan) =
        this.AddScalar(Animation.DelayBetweenIterations.WithValue(value))

    /// <summary>Sets the SpeedRatio property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SpeedRatio value.</param>
    [<Extension>]
    static member inline speedRatio(this: WidgetBuilder<'msg, #IFabAnimation>, value: float) =
        this.AddScalar(Animation.SpeedRatio.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Animation control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAnimation>, value: ViewRef<Animation>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type AnimationCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabKeyFrame>
        (
            _: CollectionBuilder<'msg, 'marker, IFabKeyFrame>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabKeyFrame>
        (
            _: CollectionBuilder<'msg, 'marker, IFabKeyFrame>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

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

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabAnimatable and 'itemType :> IFabAnimation>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabAnimatable and 'itemType :> IFabAnimation>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

[<AutoOpen>]
module AnimationAttachedBuilders =
    type Fabulous.Avalonia.View with

        /// <summary> Creates a Animation widget with the specified duration and keyframes.</summary>
        /// <param name="keyFrame">The keyframe to add to the animation.</param>
        /// <param name="duration">The duration of the animation.</param>
        static member inline Animation(keyFrame: WidgetBuilder<'msg, IFabKeyFrame>, duration: TimeSpan) =
            CollectionBuilder<'msg, IFabAnimation, IFabKeyFrame>(Animation.WidgetKey, Animation.Children, Animation.Duration.WithValue(duration)) { keyFrame }
