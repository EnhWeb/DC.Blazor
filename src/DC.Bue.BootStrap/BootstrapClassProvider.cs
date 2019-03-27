﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DC.Bue.BootStrap
{
    public class BootStrapClassProvider : IClassProvider
    {
        #region Text

        public virtual string Text( bool plaintext ) => plaintext ? "form-control-plaintext" : "form-control";

        public virtual string TextSize( Size size ) => $"{Text( false )}-{Size( size )}";

        public virtual string TextColor( Color color ) => $"text-{Color( color )}";

        public virtual string TextValidation( ValidationStatus validationStatus ) => ValidationStatus( validationStatus );

        #endregion

        #region Memo

        public virtual string Memo() => "form-control";

        public virtual string MemoValidation( ValidationStatus validationStatus ) => ValidationStatus( validationStatus );

        #endregion

        #region Select

        public virtual string Select() => UseCustomInputStyles ? "custom-select" : "form-control";

        public virtual string SelectSize( Size size ) => $"{Select()}-{Size( size )}";

        public virtual string SelectValidation( ValidationStatus validationStatus ) => ValidationStatus( validationStatus );

        #endregion

        #region Date

        public virtual string Date() => "form-control";

        public virtual string DateSize( Size size ) => $"{Date()}-{Size( size )}";

        public virtual string DateValidation( ValidationStatus validationStatus ) => ValidationStatus( validationStatus );

        #endregion

        #region Check

        public virtual string Check() => UseCustomInputStyles ? "custom-control-input" : "form-check-input";

        public virtual string CheckInline() => UseCustomInputStyles ? "custom-control-inline" : "form-check-inline";

        public virtual string CheckValidation( ValidationStatus validationStatus ) => ValidationStatus( validationStatus );

        #endregion

        #region Radio

        public virtual string Radio() => UseCustomInputStyles ? "custom-control-input" : "form-check-input";

        public virtual string RadioInline() => UseCustomInputStyles ? "custom-control-inline" : "form-check-inline";

        #endregion

        #region File

        public virtual string File() => UseCustomInputStyles ? "custom-file-input" : "form-control-file";

        public virtual string FileValidation( ValidationStatus validationStatus ) => ValidationStatus( validationStatus );

        #endregion

        #region Label

        public virtual string Label() => null;

        public virtual string LabelCheck() => UseCustomInputStyles ? "custom-control-label" : "form-check-label";

        public virtual string LabelFile() => UseCustomInputStyles ? "custom-file-label" : null;

        #endregion

        #region Help

        public virtual string Help() => "form-text text-muted";

        #endregion

        #region Validation

        public string ValidationSuccess() => "valid-feedback";

        public string ValidationSuccessTooltip() => "valid-tooltip";

        public string ValidationError() => "invalid-feedback";

        public string ValidationErrorTooltip() => "invalid-tooltip";

        #endregion

        #region Fields

        public virtual string Fields() => "form-row";

        public virtual string FieldsBody() => null;

        public virtual string FieldsColumn() => $"{Col()}";

        #endregion

        #region Field

        public virtual string Field() => "form-group";

        public virtual string FieldHorizontal() => "row";

        public virtual string FieldColumn() => $"{Col()}";

        public virtual string FieldJustifyContent( JustifyContent justifyContent ) => JustifyContent( justifyContent );

        #endregion

        #region FieldLabel

        public virtual string FieldLabel() => null;

        public virtual string FieldLabelHorizontal() => "col-form-label";

        #endregion

        #region FieldBody

        public virtual string FieldBody() => null;

        #endregion

        #region FieldHelp

        public virtual string FieldHelp() => "form-text text-muted";

        #endregion

        #region Control

        public virtual string ControlCheck() => UseCustomInputStyles ? "custom-control custom-checkbox" : "form-check";

        public virtual string ControlRadio() => UseCustomInputStyles ? "custom-control custom-radio" : "form-check";

        public virtual string ControlFile() => UseCustomInputStyles ? "custom-control custom-file" : "form-group";

        public virtual string ControlText() => null;

        #endregion

        #region Addons

        public virtual string Addons() => "input-group";

        public virtual string Addon( AddonType addonType )
        {
            switch ( addonType )
            {
                case AddonType.Start:
                    return "input-group-prepend";
                case AddonType.End:
                    return "input-group-append";
                default:
                    return null;
            }
        }

        public virtual string AddonLabel() => "input-group-text";

        public virtual string AddonContainer() => null;

        #endregion

        #region Inline

        public virtual string Inline() => "form-inline";

        #endregion

        #region Button

        public virtual string Button() => "btn";

        public virtual string ButtonColor( Color color ) => $"{Button()}-{Color( color )}";

        public virtual string ButtonOutline( Color color ) => color != DC.Bue.Color.None ? $"{Button()}-outline-{Color( color )}" : $"{Button()}-outline";

        public virtual string ButtonSize( Size size ) => $"{Button()}-{Size( size )}";

        public virtual string ButtonBlock() => $"{Button()}-block";

        public virtual string ButtonActive() => "active";

        public virtual string ButtonLoading() => null;

        #endregion

        #region Buttons

        //public virtual string Buttons() => "btn-group";

        public virtual string ButtonsAddons() => "btn-group";

        public virtual string ButtonsToolbar() => "btn-toolbar";

        public virtual string ButtonsSize( Size size ) => $"{ButtonsAddons()}-{Size( size )}";

        public virtual string ButtonsVertical() => "btn-group-vertical";

        #endregion

        #region CloseButton

        public virtual string CloseButton() => "close";

        #endregion

        #region Dropdown

        public virtual string Dropdown() => "dropdown";

        public virtual string DropdownGroup() => "btn-group";

        public virtual string DropdownShow() => Show();

        public virtual string DropdownRight() => null;

        public virtual string DropdownItem() => "dropdown-item";

        public virtual string DropdownDivider() => "dropdown-divider";

        public virtual string DropdownMenu() => "dropdown-menu";

        public virtual string DropdownMenuBody() => null;

        public virtual string DropdownMenuShow() => Show();

        public virtual string DropdownMenuRight() => "dropdown-menu-right";

        public virtual string DropdownToggle() => "dropdown-toggle";

        public virtual string DropdownToggleSplit() => "dropdown-toggle-split";

        public virtual string DropdownDirection( Direction direction )
        {
            switch ( direction )
            {
                case Direction.Up:
                    return "dropup";
                case Direction.Right:
                    return "dropright";
                case Direction.Left:
                    return "dropleft";
                case Direction.Down:
                case Direction.None:
                default:
                    return null;
            }
        }

        #endregion

        #region Tab

        public virtual string Tabs() => "nav nav-tabs";

        public virtual string TabsCards() => "card-header-tabs";

        public virtual string TabsPills() => "nav-pills";

        public virtual string TabsFullWidth() => "nav-fill";

        public virtual string TabsJustified() => "nav-justified";

        public virtual string TabsVertical() => "flex-column";

        public virtual string TabItem() => "nav-item";

        public virtual string TabItemActive() => null;

        public virtual string TabLink() => "nav-link";

        public virtual string TabLinkActive() => $"{Active()} {Show()}";

        public virtual string TabsContent() => "tab-content";

        public virtual string TabPanel() => "tab-pane";

        public virtual string TabPanelActive() => $"{Active()} {Show()}";

        #endregion

        #region Card

        public virtual string CardGroup() => "card-group";

        public virtual string Card() => "card";

        public virtual string CardWhiteText() => "text-white";

        public virtual string CardBackground( Background background ) => BackgroundColor( background );

        public virtual string CardActions() => "card-actions";

        public virtual string CardBody() => "card-body";

        public virtual string CardFooter() => "card-footer";

        public virtual string CardHeader() => "card-header";

        public virtual string CardImage() => "card-img-top";

        public virtual string CardTitle() => "card-title";

        public virtual string CardSubtitle() => "card-subtitle";

        public virtual string CardSubtitleSize( int size ) => null;

        public virtual string CardText() => "card-text";

        public virtual string CardLink() => "card-link";

        #endregion

        #region ListGroup

        public virtual string ListGroup() => "list-group";

        public virtual string ListGroupFlush() => "list-group-flush";

        public virtual string ListGroupItem() => "list-group-item";

        public virtual string ListGroupItemActive() => Active();

        public virtual string ListGroupItemDisabled() => Disabled();

        #endregion

        #region Container

        public virtual string Container() => "container";

        public virtual string ContainerFluid() => "container-fluid";

        #endregion

        #region Panel

        public virtual string Panel() => null;

        #endregion

        #region Nav

        public virtual string Nav() => "nav";

        public virtual string NavItem() => "nav-item";

        public virtual string NavLink() => "nav-link";

        public virtual string NavTabs() => "nav-tabs";

        public virtual string NavCards() => "nav-cards";

        public virtual string NavPills() => "nav-pills";

        public virtual string NavFill( NavFillType fillType ) => fillType == NavFillType.Justified ? "nav-justified" : "nav-fill";

        public virtual string NavVertical() => "flex-column";

        #endregion

        #region Navbar

        public virtual string Bar() => "navbar";

        public virtual string BarShade( Theme theme ) => $"navbar-{Theme( theme )}";

        public virtual string BarBreakpoint( Breakpoint breakpoint ) => $"navbar-expand-{Breakpoint( breakpoint )}";

        public virtual string BarItem() => "nav-item";

        public virtual string BarItemActive() => Active();

        public virtual string BarItemDisabled() => Disabled();

        public virtual string BarItemHasDropdown() => "dropdown";

        public virtual string BarItemHasDropdownShow() => Show();

        public virtual string BarLink() => "nav-link";

        public virtual string BarLinkDisabled() => Disabled();

        //public virtual string BarCollapse() => "navbar-collapse";

        public virtual string BarBrand() => "navbar-brand";

        public virtual string BarToggler() => "navbar-toggler";

        public virtual string BarMenu() => "collapse navbar-collapse";

        public virtual string BarMenuShow() => Show();

        public virtual string BarStart() => "navbar-nav mr-auto";

        public virtual string BarEnd() => "navbar-nav";

        //public virtual string BarHasDropdown() => "dropdown";

        public virtual string BarDropdown() => null;

        public virtual string BarDropdownShow() => null;

        public virtual string BarDropdownToggle() => "nav-link dropdown-toggle";

        public virtual string BarDropdownItem() => "dropdown-item";

        public virtual string BarTogglerIcon() => "navbar-toggler-icon";

        public virtual string BarDropdownMenu() => "dropdown-menu";

        public virtual string BarDropdownMenuShow() => Show();

        public virtual string BarDropdownMenuRight() => "dropdown-menu-right";

        #endregion

        #region Collapse

        public virtual string Collapse() => "collapse";

        public virtual string CollapseShow() => Show();

        #endregion

        #region Row

        public virtual string Row() => "row";

        #endregion

        #region Col

        public virtual string Col() => "col";

        public virtual string Col( ColumnWidth columnWidth, IEnumerable<(Breakpoint breakpoint, bool offset)> rules ) =>
            string.Join( " ", rules.Select( r => Col( columnWidth, r.breakpoint, r.offset ) ) );

        private string Col( ColumnWidth columnWidth, Breakpoint breakpoint, bool offset )
        {
            var baseClass = offset ? "offset" : Col();

            if ( breakpoint != DC.Bue.Breakpoint.None )
            {
                if ( columnWidth == DC.Bue.ColumnWidth.None )
                    return $"{baseClass}-{Breakpoint( breakpoint )}";

                return $"{baseClass}-{Breakpoint( breakpoint )}-{ColumnWidth( columnWidth )}";
            }

            //if ( columnWidth == DC.Bue.ColumnWidth.Auto )
            //    return $"{baseClass}";

            return $"{baseClass}-{ColumnWidth( columnWidth )}";
        }

        #endregion

        #region Alert

        public virtual string Alert() => "alert";

        public virtual string AlertColor( Color color ) => $"{Alert()}-{Color( color )}";

        public virtual string AlertDismisable() => "alert-dismissible";

        //public virtual string AlertShow( bool show ) => $"alert-dismissible {Fade()} {( show ? Show() : null )}";

        #endregion

        #region Modal

        public virtual string Modal() => "modal";

        public virtual string ModalFade() => $"{Fade()}";

        public virtual string ModalShow() => $"{Show()}";

        public virtual string ModalBackdrop() => "modal-backdrop";

        public virtual string ModalContent( bool isForm ) => "modal-content";

        public virtual string ModalContentCentered() => "modal-dialog-centered";

        public virtual string ModalBody() => "modal-body";

        public virtual string ModalHeader() => "modal-header";

        public virtual string ModalFooter() => "modal-footer";

        public virtual string ModalTitle() => "modal-title";

        #endregion

        #region Pagination

        public virtual string Pagination() => "pagination";

        public virtual string PaginationSize( Size size ) => $"{Pagination()}-{Size( size )}";

        public virtual string PaginationItem() => "page-item";

        public virtual string PaginationItemActive() => Active();

        public virtual string PaginationItemDisabled() => Disabled();

        public virtual string PaginationLink() => "page-link";

        public virtual string PaginationLinkActive() => null;

        public virtual string PaginationLinkDisabled() => null;

        #endregion

        #region Progress

        public virtual string Progress() => "progress";

        public virtual string ProgressSize( Size size ) => $"progress-{Size( size )}";

        public virtual string ProgressBar() => "progress-bar";

        public virtual string ProgressBarStriped() => "progress-bar-striped";

        public virtual string ProgressBarAnimated() => "progress-bar-animated";

        public virtual string ProgressBarWidth( int width ) => $"w-{width}";

        #endregion

        #region Chart

        public virtual string Chart() => null;

        #endregion

        #region Colors

        public virtual string BackgroundColor( Background color ) => $"bg-{Color( color )}";

        #endregion

        #region Title

        public virtual string Title() => null;

        public virtual string TitleSize( int size ) => $"h{size}";

        #endregion

        #region Table

        public virtual string Table() => "table";

        public virtual string TableFullWidth() => null;

        public virtual string TableStriped() => "table-striped";

        public virtual string TableHoverable() => "table-hover";

        public virtual string TableBordered() => "table-bordered";

        public virtual string TableHeader() => null;

        public virtual string TableHeaderCell() => null;

        public virtual string TableBody() => null;

        public virtual string TableRow() => null;

        public virtual string TableRowHeader() => null;

        public virtual string TableRowCell() => null;

        #endregion

        #region Badge

        public virtual string Badge() => "badge";

        public virtual string BadgeColor( Color color ) => $"{Badge()}-{Color( color )}";

        public virtual string BadgePill() => $"{Badge()}-pill";

        #endregion

        #region Media

        public virtual string Media() => "media";

        public virtual string MediaLeft() => "media-left";

        public virtual string MediaRight() => "media-right";

        public virtual string MediaBody() => "media-body";

        #endregion

        #region SimpleText

        public virtual string SimpleTextColor( TextColor textColor ) => $"text-{TextColor( textColor )}";

        public virtual string SimpleTextAlignment( TextAlignment textAlignment ) => $"text-{TextAlignment( textAlignment )}";

        public virtual string SimpleTextTransform( TextTransform textTransform ) => $"text-{TextTransform( textTransform )}";

        public virtual string SimpleTextWeight( TextWeight textWeight ) => $"font-weight-{TextWeight( textWeight )}";

        public virtual string SimpleTextItalic() => "font-italic";

        #endregion

        #region Heading

        public virtual string Heading( HeadingSize headingSize ) => $"h{HeadingSize( headingSize )}";

        public virtual string HeadingTextColor( TextColor textColor ) => $"text-{TextColor( textColor )}";

        #endregion

        #region Paragraph

        public virtual string Paragraph() => null;

        #endregion

        #region Figure

        public virtual string Figure() => "figure";

        #endregion

        #region Breadcrumb

        public virtual string Breadcrumb() => "breadcrumb";

        public virtual string BreadcrumbItem() => "breadcrumb-item";

        public virtual string BreadcrumbItemActive() => Active();

        public virtual string BreadcrumbLink() => null;

        #endregion

        #region States

        public virtual string Show() => "show";

        public virtual string Fade() => "fade";

        public virtual string Active() => "active";

        public virtual string Disabled() => "disabled";

        public virtual string Collapsed() => "collapsed";

        #endregion

        #region Layout

        public virtual string Spacing( Spacing spacing, SpacingSize spacingSize, Side side, Breakpoint breakpoint )
        {
            if ( breakpoint != DC.Bue.Breakpoint.None )
                return $"{Spacing( spacing )}{Side( side )}-{Breakpoint( breakpoint )}-{SpacingSize( spacingSize )}";

            return $"{Spacing( spacing )}{Side( side )}-{SpacingSize( spacingSize )}";
        }

        public virtual string Spacing( Spacing spacing, SpacingSize spacingSize, IEnumerable<(Side side, Breakpoint breakpoint)> rules ) => string.Join( " ", rules.Select( x => Spacing( spacing, spacingSize, x.side, x.breakpoint ) ) );

        #endregion

        #region Flex

        public virtual string FlexAlignment( Alignment alignment ) => $"justify-content-{Alignment( alignment )}";

        #endregion

        #region Enums

        public virtual string Size( Size size )
        {
            switch ( size )
            {
                case DC.Bue.Size.ExtraSmall:
                    return "xs";
                case DC.Bue.Size.Small:
                    return "sm";
                case DC.Bue.Size.Medium:
                    return "md";
                case DC.Bue.Size.Large:
                    return "lg";
                case DC.Bue.Size.ExtraLarge:
                    return "xl";
                default:
                    return null;
            }
        }

        public virtual string Breakpoint( Breakpoint breakpoint )
        {
            switch ( breakpoint )
            {
                case DC.Bue.Breakpoint.Mobile:
                    return "xs";
                case DC.Bue.Breakpoint.Tablet:
                    return "sm";
                case DC.Bue.Breakpoint.Desktop:
                    return "md";
                case DC.Bue.Breakpoint.Widescreen:
                    return "lg";
                case DC.Bue.Breakpoint.FullHD:
                    return "xl";
                default:
                    return null;
            }
        }

        public virtual string Color( Color color )
        {
            switch ( color )
            {
                case DC.Bue.Color.Primary:
                    return "primary";
                case DC.Bue.Color.Secondary:
                    return "secondary";
                case DC.Bue.Color.Success:
                    return "success";
                case DC.Bue.Color.Danger:
                    return "danger";
                case DC.Bue.Color.Warning:
                    return "warning";
                case DC.Bue.Color.Info:
                    return "info";
                case DC.Bue.Color.Light:
                    return "light";
                case DC.Bue.Color.Dark:
                    return "dark";
                case DC.Bue.Color.Link:
                    return "link";
                default:
                    return null;
            }
        }

        public virtual string Color( Background color )
        {
            switch ( color )
            {
                case DC.Bue.Background.Primary:
                    return "primary";
                case DC.Bue.Background.Secondary:
                    return "secondary";
                case DC.Bue.Background.Success:
                    return "success";
                case DC.Bue.Background.Danger:
                    return "danger";
                case DC.Bue.Background.Warning:
                    return "warning";
                case DC.Bue.Background.Info:
                    return "info";
                case DC.Bue.Background.Light:
                    return "light";
                case DC.Bue.Background.Dark:
                    return "dark";
                case DC.Bue.Background.White:
                    return "white";
                case DC.Bue.Background.Transparent:
                    return "transparent";
                default:
                    return null;
            }
        }

        public virtual string TextColor( TextColor textColor )
        {
            switch ( textColor )
            {
                case DC.Bue.TextColor.Primary:
                    return "primary";
                case DC.Bue.TextColor.Secondary:
                    return "secondary";
                case DC.Bue.TextColor.Success:
                    return "success";
                case DC.Bue.TextColor.Danger:
                    return "danger";
                case DC.Bue.TextColor.Warning:
                    return "warning";
                case DC.Bue.TextColor.Info:
                    return "info";
                case DC.Bue.TextColor.Light:
                    return "light";
                case DC.Bue.TextColor.Dark:
                    return "dark";
                case DC.Bue.TextColor.Body:
                    return "body";
                case DC.Bue.TextColor.Muted:
                    return "muted";
                case DC.Bue.TextColor.White:
                    return "white";
                case DC.Bue.TextColor.Black50:
                    return "black-50";
                case DC.Bue.TextColor.White50:
                    return "white-50";
                default:
                    return null;
            }
        }

        public virtual string Theme( Theme theme )
        {
            switch ( theme )
            {
                case DC.Bue.Theme.Light:
                    return "light";
                case DC.Bue.Theme.Dark:
                    return "dark";
                default:
                    return null;
            }
        }

        public virtual string Float( Float @float )
        {
            switch ( @float )
            {
                case DC.Bue.Float.Left:
                    return "float-left";
                case DC.Bue.Float.Right:
                    return "float-right";
                default:
                    return null;
            }
        }

        public virtual string Spacing( Spacing spacing )
        {
            switch ( spacing )
            {
                case DC.Bue.Spacing.Margin:
                    return "m";
                case DC.Bue.Spacing.Padding:
                    return "p";
                default:
                    return null;
            }
        }

        public virtual string Side( Side side )
        {
            switch ( side )
            {
                case DC.Bue.Side.Top:
                    return "t";
                case DC.Bue.Side.Bottom:
                    return "b";
                case DC.Bue.Side.Left:
                    return "l";
                case DC.Bue.Side.Right:
                    return "r";
                case DC.Bue.Side.X:
                    return "x";
                case DC.Bue.Side.Y:
                    return "y";
                default:
                    return null;
            }
        }

        public virtual string Alignment( Alignment alignment )
        {
            switch ( alignment )
            {
                case DC.Bue.Alignment.Start:
                    return "start";
                case DC.Bue.Alignment.Center:
                    return "center";
                case DC.Bue.Alignment.End:
                    return "end";
                default:
                    return null;
            }
        }

        public virtual string TextAlignment( TextAlignment textAlignment )
        {
            switch ( textAlignment )
            {
                case DC.Bue.TextAlignment.Left:
                    return "left";
                case DC.Bue.TextAlignment.Center:
                    return "center";
                case DC.Bue.TextAlignment.Right:
                    return "right";
                case DC.Bue.TextAlignment.Justified:
                    return "justify";
                default:
                    return null;
            }
        }

        public virtual string TextTransform( TextTransform textTransform )
        {
            switch ( textTransform )
            {
                case DC.Bue.TextTransform.Lowercase:
                    return "lowercase";
                case DC.Bue.TextTransform.Uppercase:
                    return "uppercase";
                case DC.Bue.TextTransform.Capitalize:
                    return "capitalize";
                default:
                    return null;
            }
        }

        public virtual string TextWeight( TextWeight textWeight )
        {
            switch ( textWeight )
            {
                case DC.Bue.TextWeight.Normal:
                    return "normal";
                case DC.Bue.TextWeight.Bold:
                    return "bold";
                case DC.Bue.TextWeight.Light:
                    return "light";
                default:
                    return null;
            }
        }

        public virtual string ColumnWidth( ColumnWidth columnWidth )
        {
            switch ( columnWidth )
            {
                case DC.Bue.ColumnWidth.Is1:
                    return "1";
                case DC.Bue.ColumnWidth.Is2:
                    return "2";
                case DC.Bue.ColumnWidth.Is3:
                case DC.Bue.ColumnWidth.Quarter:
                    return "3";
                case DC.Bue.ColumnWidth.Is4:
                case DC.Bue.ColumnWidth.Third:
                    return "4";
                case DC.Bue.ColumnWidth.Is5:
                    return "5";
                case DC.Bue.ColumnWidth.Is6:
                case DC.Bue.ColumnWidth.Half:
                    return "6";
                case DC.Bue.ColumnWidth.Is7:
                    return "7";
                case DC.Bue.ColumnWidth.Is8:
                    return "8";
                case DC.Bue.ColumnWidth.Is9:
                    return "9";
                case DC.Bue.ColumnWidth.Is10:
                    return "10";
                case DC.Bue.ColumnWidth.Is11:
                    return "11";
                case DC.Bue.ColumnWidth.Is12:
                case DC.Bue.ColumnWidth.Full:
                    return "12";
                case DC.Bue.ColumnWidth.Auto:
                    return "auto";
                default:
                    return null;
            }
        }

        public virtual string ModalSize( ModalSize modalSize )
        {
            switch ( modalSize )
            {
                case DC.Bue.ModalSize.Small:
                    return "modal-sm";
                case DC.Bue.ModalSize.Large:
                    return "modal-lg";
                case DC.Bue.ModalSize.ExtraLarge:
                    return "modal-xl";
                case DC.Bue.ModalSize.Default:
                default:
                    return null;
            }
        }

        public virtual string SpacingSize( SpacingSize spacingSize )
        {
            switch ( spacingSize )
            {
                case DC.Bue.SpacingSize.Is0:
                    return "0";
                case DC.Bue.SpacingSize.Is1:
                    return "1";
                case DC.Bue.SpacingSize.Is2:
                    return "2";
                case DC.Bue.SpacingSize.Is3:
                    return "3";
                case DC.Bue.SpacingSize.Is4:
                    return "4";
                case DC.Bue.SpacingSize.Is5:
                    return "5";
                case DC.Bue.SpacingSize.IsAuto:
                    return "auto";
                default:
                    return null;
            }
        }

        public virtual string JustifyContent( JustifyContent justifyContent )
        {
            switch ( justifyContent )
            {
                case DC.Bue.JustifyContent.Start:
                    return "justify-content-start";
                case DC.Bue.JustifyContent.End:
                    return "justify-content-end";
                case DC.Bue.JustifyContent.Center:
                    return "justify-content-center";
                case DC.Bue.JustifyContent.Between:
                    return "justify-content-between";
                case DC.Bue.JustifyContent.Around:
                    return "justify-content-around";
                default:
                    return null;
            }
        }

        public virtual string Screenreader( Screenreader screenreader )
        {
            switch ( screenreader )
            {
                case DC.Bue.Screenreader.Only:
                    return "sr-only";
                case DC.Bue.Screenreader.OnlyFocusable:
                    return "sr-only-focusable";
                default:
                    return null;
            }
        }

        public virtual string HeadingSize( HeadingSize headingSize )
        {
            switch ( headingSize )
            {
                case DC.Bue.HeadingSize.Is1:
                    return "1";
                case DC.Bue.HeadingSize.Is2:
                    return "2";
                case DC.Bue.HeadingSize.Is3:
                    return "3";
                case DC.Bue.HeadingSize.Is4:
                    return "4";
                case DC.Bue.HeadingSize.Is5:
                    return "5";
                case DC.Bue.HeadingSize.Is6:
                    return "6";
                default:
                    return null;
            }
        }

        public virtual string ValidationStatus( ValidationStatus validationStatus )
        {
            switch ( validationStatus )
            {
                case DC.Bue.ValidationStatus.Success:
                    return "is-valid";
                case DC.Bue.ValidationStatus.Error:
                    return "is-invalid";
                default:
                    return null;
            }
        }

        #endregion

        public virtual bool UseCustomInputStyles { get; set; } = true;

        public virtual string Provider => "BootStrap";
    }
}
