using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using Atalasoft.Imaging;
using Atalasoft.Imaging.Codec;
using Atalasoft.Annotate.UI;
using Atalasoft.Annotate;
using Atalasoft.Annotate.Icons;
using System.Reflection;
using WinDemoHelperMethods;

namespace DotAnnotateDemo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private ApplicationPreferences _appSettings;
        private string _lastOpenDirectory = "";
        private TemplateManager _templates;
        private Atalasoft.Annotate.Pdf.PdfMarkupAnnotation _lastPdfAnnotation;
        private bool _pdfAnnotationSupport;

        private System.Windows.Forms.MenuItem[] _layerMenus;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuFileOpen;
        private System.Windows.Forms.MenuItem menuFileSave;
        private System.Windows.Forms.MenuItem menuFileNextPage;
        private System.Windows.Forms.MenuItem menuFilePreviousPage;
        private System.Windows.Forms.MenuItem menuFilePrint;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuAnnotations;
        private System.Windows.Forms.MenuItem menuAnnotationsLoad;
        private System.Windows.Forms.MenuItem menuAnnotationsSave;
        private System.Windows.Forms.MenuItem menuAnnotationsAdd;
        private System.Windows.Forms.MenuItem menuHelp;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.MenuItem menuAnnotationsRemove;
        private System.Windows.Forms.MenuItem menuLayers;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusPage;
        private Atalasoft.Annotate.UI.AnnotateViewer annotateViewer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuAddEllipse;
        private System.Windows.Forms.MenuItem menuAddRectangle;
        private System.Windows.Forms.MenuItem menuAddPolygon;
        private System.Windows.Forms.MenuItem menuAddLine;
        private System.Windows.Forms.MenuItem menuAddLines;
        private System.Windows.Forms.MenuItem menuAddText;
        private System.Windows.Forms.MenuItem menuAddRubberStamp;
        private System.Windows.Forms.MenuItem menuAddEmbeddedImage;
        private System.Windows.Forms.MenuItem menuAddReferencedImage;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLayer;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panelAnnotation;
        private System.Windows.Forms.PropertyGrid propGridAnnotation;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.MenuItem menuLayersClear;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuLayersClearAll;
        private System.Windows.Forms.MenuItem menuLayersAdd;
        private System.Windows.Forms.MenuItem menuLayersRemove;
        private System.Windows.Forms.MenuItem menuAddFreehand;
        private System.Windows.Forms.MenuItem menuAnnotationsFlip;
        private System.Windows.Forms.MenuItem menuFlipH;
        private System.Windows.Forms.MenuItem menuFlipV;
        private System.Windows.Forms.MenuItem menuAnnotationsTooltips;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuItem menuFileBurn;
        private System.Windows.Forms.MenuItem menuZoom;
        private System.Windows.Forms.MenuItem menuZoom25;
        private System.Windows.Forms.MenuItem menuZoom50;
        private System.Windows.Forms.MenuItem menuZoom100;
        private System.Windows.Forms.MenuItem menuZoom200;
        private System.Windows.Forms.MenuItem menuZoom500;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuAnnGroup;
        private System.Windows.Forms.MenuItem menuAnnUngroup;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuEdit;
        private System.Windows.Forms.MenuItem menuEditUndo;
        private System.Windows.Forms.MenuItem menuEditRedo;
        private System.Windows.Forms.MenuItem menuEditCut;
        private System.Windows.Forms.MenuItem menuEditCopy;
        private System.Windows.Forms.MenuItem menuEditPaste;
        private System.Windows.Forms.MenuItem menuEditSelectAll;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuEditPreferences;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.StatusBarPanel statusFile;
        private System.Windows.Forms.StatusBarPanel statusAnnCount;
        private System.Windows.Forms.PropertyGrid propGridTemplate;
        private System.Windows.Forms.MenuItem menuAnnotationsMoveToFront;
        private System.Windows.Forms.MenuItem menuAnnotationsMoveUp;
        private System.Windows.Forms.MenuItem menuAnnotationsMoveBack;
        private System.Windows.Forms.MenuItem menuAnnotationsMoveToBack;
        private System.Windows.Forms.MenuItem menuLayersMoveToFront;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuLayersMoveUp;
        private System.Windows.Forms.MenuItem menuLayersMoveBack;
        private System.Windows.Forms.MenuItem menuLayersMoveToBack;
        private System.Windows.Forms.MenuItem menuFileRotate;
        private System.Windows.Forms.MenuItem menuEnableClassyRenderers;
        private System.Windows.Forms.StatusBarPanel statusInfo;
        private System.Windows.Forms.MenuItem menuAddCallout;
        private System.Windows.Forms.StatusBarPanel statusResolution;
        private System.Windows.Forms.MenuItem menuAddTriangle;
        private System.Windows.Forms.MenuItem menuAddHotSpot;
        private System.Windows.Forms.MenuItem menuAddFreehandHotSpot;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuSecurity;
        private System.Windows.Forms.MenuItem menuSecurityLockAnnotations;
        private System.Windows.Forms.MenuItem menuSecurityLockLayer;
        private System.Windows.Forms.MenuItem menuSecurityUnlockAnnotations;
        private System.Windows.Forms.MenuItem menuSecurityUnlockLayer;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuSecuritySelectImage;
        private System.Windows.Forms.MenuItem menuSecurityClearImage;
        private System.Windows.Forms.MenuItem menuEditClearUndos;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbEllipse;
        private System.Windows.Forms.ToolBarButton tbFreehand;
        private System.Windows.Forms.ToolBarButton tbFreehandHighlighter;
        private System.Windows.Forms.ToolBarButton tbLine;
        private System.Windows.Forms.ToolBarButton tbLines;
        private System.Windows.Forms.ToolBarButton tbPolygon;
        private System.Windows.Forms.ToolBarButton tbRetangle;
        private System.Windows.Forms.ToolBarButton tbRectangleHighlighter;
        private System.Windows.Forms.ToolBarButton tbRedaction;
        private System.Windows.Forms.ToolBarButton tbStickyNote;
        private System.Windows.Forms.ToolBarButton tbText;
        private System.Windows.Forms.ImageList toolImageList;
        private System.Windows.Forms.ToolBarButton tbRubberStamp;
        private System.Windows.Forms.ToolBarButton tbCallout;
        private System.Windows.Forms.ToolBarButton tbFreehandHotspot;
        private System.Windows.Forms.ToolBarButton tbRectangleHotspot;
        private System.Windows.Forms.MenuItem menuInteractMode;
        private System.Windows.Forms.MenuItem menuInteractModeView;
        private System.Windows.Forms.MenuItem menuInteractModeNone;
        private System.Windows.Forms.ToolBarButton tbEmbeddedImage;
        private System.Windows.Forms.ToolBarButton tbReferencedImage;
        private System.Windows.Forms.ToolBarButton tbSep1;
        private System.Windows.Forms.ToolBarButton tbSep2;
        private System.Windows.Forms.ToolBarButton tbSep3;
        private System.Windows.Forms.ToolBarButton tbSep4;
        private System.Windows.Forms.MenuItem menuInteractModeAuthor;
        private System.Windows.Forms.ToolBarButton tbPdfMarkup;
        private System.Windows.Forms.ToolBarButton tbPdfLine;
        private System.Windows.Forms.ToolBarButton tbSep5;
        private System.Windows.Forms.MenuItem menuPdfHighlight;
        private System.Windows.Forms.MenuItem menuPdfSquiggly;
        private System.Windows.Forms.MenuItem menuPdfStrikeOut;
        private System.Windows.Forms.MenuItem menuPdfUnderline;
        private System.Windows.Forms.ContextMenu contextPdf;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuAddPdfLine;
        private System.Windows.Forms.MenuItem menuAddPdfHighlighter;
        private System.Windows.Forms.MenuItem menuAddPdfSquiggly;
        private System.Windows.Forms.MenuItem menuAddPdfUnderline;
        private System.Windows.Forms.MenuItem menuAddPdfStrikeout;
        private System.Windows.Forms.MenuItem menuItem24;
        private System.Windows.Forms.MenuItem menuAddTrianglePoints;
        private ToolBarButton tbTriangle;
        private ToolBarButton tbTrianglePoint;
        private ToolBarButton tbArc;
        private ToolBarButton tbSpacer1;
        private ToolBarButton tbSpacer2;
        private System.ComponentModel.IContainer components;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // Get all licensed decoders
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders);

            // SAFELY determine if we have PDF annotations and add support for the importer if we do
            try
            {
                if (HelperMethods.HaveDecoder(new Atalasoft.Imaging.Codec.Pdf.PdfDecoder()))
                {
                    // The imports allows the annotations to automatically load with the Open method.
                    this.annotateViewer1.DataImporters.Add(new Atalasoft.Annotate.Importers.PdfAnnotationDataImporter());
                    _pdfAnnotationSupport = true;
                }
                else
                {
                    _pdfAnnotationSupport = false;
                }
            }
            catch (AtalasoftLicenseException)
            {
                _pdfAnnotationSupport = false;
            }

            this.annotateViewer1.Annotations.SelectionChanged += new EventHandler(Annotations_SelectionChanged);
            this.annotateViewer1.Annotations.AnnotationCreated += new AnnotationEventHandler(Annotations_AnnotationCreated);
            this.annotateViewer1.Annotations.Rotating += new AnnotationEventHandler(Annotations_Rotating);
            this.annotateViewer1.Annotations.Moving += new AnnotationEventHandler(Annotations_Moving);
            this.annotateViewer1.Annotations.Resizing += new AnnotationEventHandler(Annotations_Resizing);
            this.annotateViewer1.Annotations.Moved += new AnnotationEventHandler(Annotations_MovedResizedRotated);
            this.annotateViewer1.Annotations.Resized += new AnnotationEventHandler(Annotations_MovedResizedRotated);
            this.annotateViewer1.Annotations.Rotated += new AnnotationEventHandler(Annotations_MovedResizedRotated);

            this.annotateViewer1.Centered = false;

            // Add the custom annotation factories.
            this.annotateViewer1.Annotations.Factories.Add(new TriangleAnnotationFactory());
            this.annotateViewer1.Annotations.Factories.Add(new TrianglePointAnnotationFactory());
            this.annotateViewer1.Annotations.Factories.Add(new ArcAnnotationFactory());

            this._templates = new TemplateManager();
            this.propGridTemplate.SelectedObject = this._templates;
            UpdateMenu();
            UpdateInteractModeMenu();
            ApplyAppSettings();

            this.propGridAnnotation.PropertyValueChanged += new PropertyValueChangedEventHandler(propGridAnnotation_PropertyValueChanged);
            this.annotateViewer1.Annotations.ClipToDocument = true;
            PopulateToolbox();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuFileSave = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuFileNextPage = new System.Windows.Forms.MenuItem();
            this.menuFilePreviousPage = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuFilePrint = new System.Windows.Forms.MenuItem();
            this.menuFileBurn = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuFileRotate = new System.Windows.Forms.MenuItem();
            this.menuZoom = new System.Windows.Forms.MenuItem();
            this.menuZoom25 = new System.Windows.Forms.MenuItem();
            this.menuZoom50 = new System.Windows.Forms.MenuItem();
            this.menuZoom100 = new System.Windows.Forms.MenuItem();
            this.menuZoom200 = new System.Windows.Forms.MenuItem();
            this.menuZoom500 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuEdit = new System.Windows.Forms.MenuItem();
            this.menuEditUndo = new System.Windows.Forms.MenuItem();
            this.menuEditRedo = new System.Windows.Forms.MenuItem();
            this.menuEditClearUndos = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuEditCut = new System.Windows.Forms.MenuItem();
            this.menuEditCopy = new System.Windows.Forms.MenuItem();
            this.menuEditPaste = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuEditSelectAll = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuEditPreferences = new System.Windows.Forms.MenuItem();
            this.menuAnnotations = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsLoad = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsSave = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsAdd = new System.Windows.Forms.MenuItem();
            this.menuAddCallout = new System.Windows.Forms.MenuItem();
            this.menuAddEllipse = new System.Windows.Forms.MenuItem();
            this.menuAddEmbeddedImage = new System.Windows.Forms.MenuItem();
            this.menuAddFreehand = new System.Windows.Forms.MenuItem();
            this.menuAddFreehandHotSpot = new System.Windows.Forms.MenuItem();
            this.menuAddHotSpot = new System.Windows.Forms.MenuItem();
            this.menuAddLine = new System.Windows.Forms.MenuItem();
            this.menuAddLines = new System.Windows.Forms.MenuItem();
            this.menuAddPolygon = new System.Windows.Forms.MenuItem();
            this.menuAddRectangle = new System.Windows.Forms.MenuItem();
            this.menuAddReferencedImage = new System.Windows.Forms.MenuItem();
            this.menuAddRubberStamp = new System.Windows.Forms.MenuItem();
            this.menuAddText = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuAddPdfLine = new System.Windows.Forms.MenuItem();
            this.menuAddPdfHighlighter = new System.Windows.Forms.MenuItem();
            this.menuAddPdfSquiggly = new System.Windows.Forms.MenuItem();
            this.menuAddPdfStrikeout = new System.Windows.Forms.MenuItem();
            this.menuAddPdfUnderline = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuAddTriangle = new System.Windows.Forms.MenuItem();
            this.menuAddTrianglePoints = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsRemove = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsMoveToFront = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsMoveUp = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsMoveBack = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsMoveToBack = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsFlip = new System.Windows.Forms.MenuItem();
            this.menuFlipH = new System.Windows.Forms.MenuItem();
            this.menuFlipV = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuAnnGroup = new System.Windows.Forms.MenuItem();
            this.menuAnnUngroup = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuEnableClassyRenderers = new System.Windows.Forms.MenuItem();
            this.menuAnnotationsTooltips = new System.Windows.Forms.MenuItem();
            this.menuInteractMode = new System.Windows.Forms.MenuItem();
            this.menuInteractModeNone = new System.Windows.Forms.MenuItem();
            this.menuInteractModeAuthor = new System.Windows.Forms.MenuItem();
            this.menuInteractModeView = new System.Windows.Forms.MenuItem();
            this.menuLayers = new System.Windows.Forms.MenuItem();
            this.menuLayersClear = new System.Windows.Forms.MenuItem();
            this.menuLayersClearAll = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuLayersAdd = new System.Windows.Forms.MenuItem();
            this.menuLayersRemove = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuLayersMoveToFront = new System.Windows.Forms.MenuItem();
            this.menuLayersMoveUp = new System.Windows.Forms.MenuItem();
            this.menuLayersMoveBack = new System.Windows.Forms.MenuItem();
            this.menuLayersMoveToBack = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuSecurity = new System.Windows.Forms.MenuItem();
            this.menuSecurityLockAnnotations = new System.Windows.Forms.MenuItem();
            this.menuSecurityLockLayer = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuSecurityUnlockAnnotations = new System.Windows.Forms.MenuItem();
            this.menuSecurityUnlockLayer = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuSecuritySelectImage = new System.Windows.Forms.MenuItem();
            this.menuSecurityClearImage = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusFile = new System.Windows.Forms.StatusBarPanel();
            this.statusInfo = new System.Windows.Forms.StatusBarPanel();
            this.statusPage = new System.Windows.Forms.StatusBarPanel();
            this.statusAnnCount = new System.Windows.Forms.StatusBarPanel();
            this.statusResolution = new System.Windows.Forms.StatusBarPanel();
            this.annotateViewer1 = new Atalasoft.Annotate.UI.AnnotateViewer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelAnnotation = new System.Windows.Forms.Panel();
            this.propGridAnnotation = new System.Windows.Forms.PropertyGrid();
            this.lblActive = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panelLayer = new System.Windows.Forms.Panel();
            this.lblLayer = new System.Windows.Forms.Label();
            this.propGridTemplate = new System.Windows.Forms.PropertyGrid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbEllipse = new System.Windows.Forms.ToolBarButton();
            this.tbFreehand = new System.Windows.Forms.ToolBarButton();
            this.tbLine = new System.Windows.Forms.ToolBarButton();
            this.tbLines = new System.Windows.Forms.ToolBarButton();
            this.tbPolygon = new System.Windows.Forms.ToolBarButton();
            this.tbRetangle = new System.Windows.Forms.ToolBarButton();
            this.tbTriangle = new System.Windows.Forms.ToolBarButton();
            this.tbTrianglePoint = new System.Windows.Forms.ToolBarButton();
            this.tbArc = new System.Windows.Forms.ToolBarButton();
            this.tbSpacer1 = new System.Windows.Forms.ToolBarButton();
            this.tbSep1 = new System.Windows.Forms.ToolBarButton();
            this.tbRectangleHighlighter = new System.Windows.Forms.ToolBarButton();
            this.tbFreehandHighlighter = new System.Windows.Forms.ToolBarButton();
            this.tbSep2 = new System.Windows.Forms.ToolBarButton();
            this.tbEmbeddedImage = new System.Windows.Forms.ToolBarButton();
            this.tbReferencedImage = new System.Windows.Forms.ToolBarButton();
            this.tbSep3 = new System.Windows.Forms.ToolBarButton();
            this.tbRectangleHotspot = new System.Windows.Forms.ToolBarButton();
            this.tbFreehandHotspot = new System.Windows.Forms.ToolBarButton();
            this.tbSep4 = new System.Windows.Forms.ToolBarButton();
            this.tbText = new System.Windows.Forms.ToolBarButton();
            this.tbCallout = new System.Windows.Forms.ToolBarButton();
            this.tbStickyNote = new System.Windows.Forms.ToolBarButton();
            this.tbRubberStamp = new System.Windows.Forms.ToolBarButton();
            this.tbRedaction = new System.Windows.Forms.ToolBarButton();
            this.tbSpacer2 = new System.Windows.Forms.ToolBarButton();
            this.tbSep5 = new System.Windows.Forms.ToolBarButton();
            this.tbPdfMarkup = new System.Windows.Forms.ToolBarButton();
            this.contextPdf = new System.Windows.Forms.ContextMenu();
            this.menuPdfHighlight = new System.Windows.Forms.MenuItem();
            this.menuPdfSquiggly = new System.Windows.Forms.MenuItem();
            this.menuPdfStrikeOut = new System.Windows.Forms.MenuItem();
            this.menuPdfUnderline = new System.Windows.Forms.MenuItem();
            this.tbPdfLine = new System.Windows.Forms.ToolBarButton();
            this.toolImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statusFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusAnnCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusResolution)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelAnnotation.SuspendLayout();
            this.panelLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuAnnotations,
            this.menuLayers,
            this.menuSecurity,
            this.menuHelp});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileOpen,
            this.menuFileSave,
            this.menuItem4,
            this.menuFileNextPage,
            this.menuFilePreviousPage,
            this.menuItem7,
            this.menuFilePrint,
            this.menuFileBurn,
            this.menuItem9,
            this.menuFileRotate,
            this.menuZoom,
            this.menuItem5,
            this.menuExit});
            this.menuFile.Text = "&File";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 0;
            this.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuFileOpen.Text = "&Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 1;
            this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuFileNextPage
            // 
            this.menuFileNextPage.Index = 3;
            this.menuFileNextPage.Text = "Next Page";
            this.menuFileNextPage.Click += new System.EventHandler(this.menuFileNextPage_Click);
            // 
            // menuFilePreviousPage
            // 
            this.menuFilePreviousPage.Index = 4;
            this.menuFilePreviousPage.Text = "Previous Page";
            this.menuFilePreviousPage.Click += new System.EventHandler(this.menuFilePreviousPage_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "-";
            // 
            // menuFilePrint
            // 
            this.menuFilePrint.Index = 6;
            this.menuFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuFilePrint.Text = "&Print";
            this.menuFilePrint.Click += new System.EventHandler(this.menuFilePrint_Click);
            // 
            // menuFileBurn
            // 
            this.menuFileBurn.Index = 7;
            this.menuFileBurn.Text = "Burn";
            this.menuFileBurn.Click += new System.EventHandler(this.menuFileBurn_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 8;
            this.menuItem9.Text = "-";
            // 
            // menuFileRotate
            // 
            this.menuFileRotate.Index = 9;
            this.menuFileRotate.Text = "Rotate Document";
            this.menuFileRotate.Click += new System.EventHandler(this.menuFileRotate_Click);
            // 
            // menuZoom
            // 
            this.menuZoom.Index = 10;
            this.menuZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuZoom25,
            this.menuZoom50,
            this.menuZoom100,
            this.menuZoom200,
            this.menuZoom500});
            this.menuZoom.Text = "Zoom";
            // 
            // menuZoom25
            // 
            this.menuZoom25.Index = 0;
            this.menuZoom25.RadioCheck = true;
            this.menuZoom25.Text = "25%";
            this.menuZoom25.Click += new System.EventHandler(this.menuZoom_Click);
            // 
            // menuZoom50
            // 
            this.menuZoom50.Index = 1;
            this.menuZoom50.RadioCheck = true;
            this.menuZoom50.Text = "50%";
            this.menuZoom50.Click += new System.EventHandler(this.menuZoom_Click);
            // 
            // menuZoom100
            // 
            this.menuZoom100.Checked = true;
            this.menuZoom100.Index = 2;
            this.menuZoom100.RadioCheck = true;
            this.menuZoom100.Text = "100%";
            this.menuZoom100.Click += new System.EventHandler(this.menuZoom_Click);
            // 
            // menuZoom200
            // 
            this.menuZoom200.Index = 3;
            this.menuZoom200.RadioCheck = true;
            this.menuZoom200.Text = "200%";
            this.menuZoom200.Click += new System.EventHandler(this.menuZoom_Click);
            // 
            // menuZoom500
            // 
            this.menuZoom500.Index = 4;
            this.menuZoom500.RadioCheck = true;
            this.menuZoom500.Text = "500%";
            this.menuZoom500.Click += new System.EventHandler(this.menuZoom_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 11;
            this.menuItem5.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 12;
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Index = 1;
            this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuEditUndo,
            this.menuEditRedo,
            this.menuEditClearUndos,
            this.menuItem13,
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste,
            this.menuItem19,
            this.menuEditSelectAll,
            this.menuItem6,
            this.menuEditPreferences});
            this.menuEdit.Text = "&Edit";
            this.menuEdit.Popup += new System.EventHandler(this.menuEdit_Popup);
            // 
            // menuEditUndo
            // 
            this.menuEditUndo.Index = 0;
            this.menuEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuEditUndo.Text = "&Undo";
            this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            // 
            // menuEditRedo
            // 
            this.menuEditRedo.Index = 1;
            this.menuEditRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.menuEditRedo.Text = "&Redo";
            this.menuEditRedo.Click += new System.EventHandler(this.menuEditRedo_Click);
            // 
            // menuEditClearUndos
            // 
            this.menuEditClearUndos.Index = 2;
            this.menuEditClearUndos.Text = "Clear Undos";
            this.menuEditClearUndos.Click += new System.EventHandler(this.menuEditClearUndos_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "-";
            // 
            // menuEditCut
            // 
            this.menuEditCut.Index = 4;
            this.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEditCut.Text = "Cu&t";
            this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Index = 5;
            this.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuEditCopy.Text = "&Copy";
            this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // menuEditPaste
            // 
            this.menuEditPaste.Index = 6;
            this.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuEditPaste.Text = "&Paste";
            this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 7;
            this.menuItem19.Text = "-";
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Index = 8;
            this.menuEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuEditSelectAll.Text = "Select &All";
            this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 9;
            this.menuItem6.Text = "-";
            // 
            // menuEditPreferences
            // 
            this.menuEditPreferences.Index = 10;
            this.menuEditPreferences.Text = "&Preferences...";
            this.menuEditPreferences.Click += new System.EventHandler(this.menuEditPreferences_Click);
            // 
            // menuAnnotations
            // 
            this.menuAnnotations.Index = 2;
            this.menuAnnotations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAnnotationsLoad,
            this.menuAnnotationsSave,
            this.menuItem17,
            this.menuAnnotationsAdd,
            this.menuAnnotationsRemove,
            this.menuItem22,
            this.menuAnnotationsMoveToFront,
            this.menuAnnotationsMoveUp,
            this.menuAnnotationsMoveBack,
            this.menuAnnotationsMoveToBack,
            this.menuItem1,
            this.menuAnnotationsFlip,
            this.menuItem2,
            this.menuAnnGroup,
            this.menuAnnUngroup,
            this.menuItem11,
            this.menuEnableClassyRenderers,
            this.menuAnnotationsTooltips,
            this.menuInteractMode});
            this.menuAnnotations.Text = "&Annotations";
            // 
            // menuAnnotationsLoad
            // 
            this.menuAnnotationsLoad.Index = 0;
            this.menuAnnotationsLoad.Text = "&Load From File";
            this.menuAnnotationsLoad.Click += new System.EventHandler(this.menuAnnotationsLoad_Click);
            // 
            // menuAnnotationsSave
            // 
            this.menuAnnotationsSave.Index = 1;
            this.menuAnnotationsSave.Text = "&Save To File";
            this.menuAnnotationsSave.Click += new System.EventHandler(this.menuAnnotationsSave_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 2;
            this.menuItem17.Text = "-";
            // 
            // menuAnnotationsAdd
            // 
            this.menuAnnotationsAdd.Index = 3;
            this.menuAnnotationsAdd.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAddCallout,
            this.menuAddEllipse,
            this.menuAddEmbeddedImage,
            this.menuAddFreehand,
            this.menuAddFreehandHotSpot,
            this.menuAddHotSpot,
            this.menuAddLine,
            this.menuAddLines,
            this.menuAddPolygon,
            this.menuAddRectangle,
            this.menuAddReferencedImage,
            this.menuAddRubberStamp,
            this.menuAddText,
            this.menuItem14,
            this.menuAddPdfLine,
            this.menuAddPdfHighlighter,
            this.menuAddPdfSquiggly,
            this.menuAddPdfStrikeout,
            this.menuAddPdfUnderline,
            this.menuItem24,
            this.menuAddTriangle,
            this.menuAddTrianglePoints});
            this.menuAnnotationsAdd.Text = "Add";
            // 
            // menuAddCallout
            // 
            this.menuAddCallout.Index = 0;
            this.menuAddCallout.Text = "Callout";
            this.menuAddCallout.Click += new System.EventHandler(this.menuAddCallout_Click);
            // 
            // menuAddEllipse
            // 
            this.menuAddEllipse.Index = 1;
            this.menuAddEllipse.Text = "Ellipse";
            this.menuAddEllipse.Click += new System.EventHandler(this.menuAddEllipse_Click);
            // 
            // menuAddEmbeddedImage
            // 
            this.menuAddEmbeddedImage.Index = 2;
            this.menuAddEmbeddedImage.Text = "Embedded Image";
            this.menuAddEmbeddedImage.Click += new System.EventHandler(this.menuAddEmbeddedImage_Click);
            // 
            // menuAddFreehand
            // 
            this.menuAddFreehand.Index = 3;
            this.menuAddFreehand.Text = "Freehand";
            this.menuAddFreehand.Click += new System.EventHandler(this.menuAddFreehand_Click);
            // 
            // menuAddFreehandHotSpot
            // 
            this.menuAddFreehandHotSpot.Index = 4;
            this.menuAddFreehandHotSpot.Text = "Freehand Hot Spot";
            this.menuAddFreehandHotSpot.Click += new System.EventHandler(this.menuAddFreehandHotSpot_Click);
            // 
            // menuAddHotSpot
            // 
            this.menuAddHotSpot.Index = 5;
            this.menuAddHotSpot.Text = "Hot Spot";
            this.menuAddHotSpot.Click += new System.EventHandler(this.menuAddHotSpot_Click);
            // 
            // menuAddLine
            // 
            this.menuAddLine.Index = 6;
            this.menuAddLine.Text = "Line";
            this.menuAddLine.Click += new System.EventHandler(this.menuAddLine_Click);
            // 
            // menuAddLines
            // 
            this.menuAddLines.Index = 7;
            this.menuAddLines.Text = "Lines";
            this.menuAddLines.Click += new System.EventHandler(this.menuAddLines_Click);
            // 
            // menuAddPolygon
            // 
            this.menuAddPolygon.Index = 8;
            this.menuAddPolygon.Text = "Polygon";
            this.menuAddPolygon.Click += new System.EventHandler(this.menuAddPolygon_Click);
            // 
            // menuAddRectangle
            // 
            this.menuAddRectangle.Index = 9;
            this.menuAddRectangle.Text = "Rectangle";
            this.menuAddRectangle.Click += new System.EventHandler(this.menuAddRectangle_Click);
            // 
            // menuAddReferencedImage
            // 
            this.menuAddReferencedImage.Index = 10;
            this.menuAddReferencedImage.Text = "Referenced Image";
            this.menuAddReferencedImage.Click += new System.EventHandler(this.menuAddReferencedImage_Click);
            // 
            // menuAddRubberStamp
            // 
            this.menuAddRubberStamp.Index = 11;
            this.menuAddRubberStamp.Text = "Rubber Stamp";
            this.menuAddRubberStamp.Click += new System.EventHandler(this.menuAddRubberStamp_Click);
            // 
            // menuAddText
            // 
            this.menuAddText.Index = 12;
            this.menuAddText.Text = "Text";
            this.menuAddText.Click += new System.EventHandler(this.menuAddText_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 13;
            this.menuItem14.Text = "-";
            // 
            // menuAddPdfLine
            // 
            this.menuAddPdfLine.Index = 14;
            this.menuAddPdfLine.Text = "PDF Line";
            this.menuAddPdfLine.Click += new System.EventHandler(this.menuAddPdfLine_Click);
            // 
            // menuAddPdfHighlighter
            // 
            this.menuAddPdfHighlighter.Index = 15;
            this.menuAddPdfHighlighter.Text = "PDF Highlighter";
            this.menuAddPdfHighlighter.Click += new System.EventHandler(this.menuAddPdfHighlighter_Click);
            // 
            // menuAddPdfSquiggly
            // 
            this.menuAddPdfSquiggly.Index = 16;
            this.menuAddPdfSquiggly.Text = "PDF Squiggly";
            this.menuAddPdfSquiggly.Click += new System.EventHandler(this.menuAddPdfSquiggly_Click);
            // 
            // menuAddPdfStrikeout
            // 
            this.menuAddPdfStrikeout.Index = 17;
            this.menuAddPdfStrikeout.Text = "PDF Strikeout";
            this.menuAddPdfStrikeout.Click += new System.EventHandler(this.menuAddPdfStrikeout_Click);
            // 
            // menuAddPdfUnderline
            // 
            this.menuAddPdfUnderline.Index = 18;
            this.menuAddPdfUnderline.Text = "PDF Underline";
            this.menuAddPdfUnderline.Click += new System.EventHandler(this.menuAddPdfUnderline_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 19;
            this.menuItem24.Text = "-";
            // 
            // menuAddTriangle
            // 
            this.menuAddTriangle.Index = 20;
            this.menuAddTriangle.Text = "Triangle (Custom Example)";
            this.menuAddTriangle.Click += new System.EventHandler(this.menuAddTriangle_Click);
            // 
            // menuAddTrianglePoints
            // 
            this.menuAddTrianglePoints.Index = 21;
            this.menuAddTrianglePoints.Text = "Triangle (Custom Point Example)";
            this.menuAddTrianglePoints.Click += new System.EventHandler(this.menuAddTrianglePoints_Click);
            // 
            // menuAnnotationsRemove
            // 
            this.menuAnnotationsRemove.Index = 4;
            this.menuAnnotationsRemove.Shortcut = System.Windows.Forms.Shortcut.ShiftDel;
            this.menuAnnotationsRemove.Text = "Remove Selected";
            this.menuAnnotationsRemove.Click += new System.EventHandler(this.menuAnnotationsRemove_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 5;
            this.menuItem22.Text = "-";
            // 
            // menuAnnotationsMoveToFront
            // 
            this.menuAnnotationsMoveToFront.Index = 6;
            this.menuAnnotationsMoveToFront.Text = "Move To Front";
            this.menuAnnotationsMoveToFront.Click += new System.EventHandler(this.menuAnnotationsMove_Click);
            // 
            // menuAnnotationsMoveUp
            // 
            this.menuAnnotationsMoveUp.Index = 7;
            this.menuAnnotationsMoveUp.Text = "Move Up";
            this.menuAnnotationsMoveUp.Click += new System.EventHandler(this.menuAnnotationsMove_Click);
            // 
            // menuAnnotationsMoveBack
            // 
            this.menuAnnotationsMoveBack.Index = 8;
            this.menuAnnotationsMoveBack.Text = "Move Back";
            this.menuAnnotationsMoveBack.Click += new System.EventHandler(this.menuAnnotationsMove_Click);
            // 
            // menuAnnotationsMoveToBack
            // 
            this.menuAnnotationsMoveToBack.Index = 9;
            this.menuAnnotationsMoveToBack.Text = "Move To Back";
            this.menuAnnotationsMoveToBack.Click += new System.EventHandler(this.menuAnnotationsMove_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 10;
            this.menuItem1.Text = "-";
            // 
            // menuAnnotationsFlip
            // 
            this.menuAnnotationsFlip.Index = 11;
            this.menuAnnotationsFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFlipH,
            this.menuFlipV});
            this.menuAnnotationsFlip.Text = "Flip";
            // 
            // menuFlipH
            // 
            this.menuFlipH.Index = 0;
            this.menuFlipH.Text = "Horizontal";
            this.menuFlipH.Click += new System.EventHandler(this.menuFlipH_Click);
            // 
            // menuFlipV
            // 
            this.menuFlipV.Index = 1;
            this.menuFlipV.Text = "Vertical";
            this.menuFlipV.Click += new System.EventHandler(this.menuFlipV_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 12;
            this.menuItem2.Text = "-";
            // 
            // menuAnnGroup
            // 
            this.menuAnnGroup.Enabled = false;
            this.menuAnnGroup.Index = 13;
            this.menuAnnGroup.Text = "&Group";
            this.menuAnnGroup.Click += new System.EventHandler(this.menuAnnGroup_Click);
            // 
            // menuAnnUngroup
            // 
            this.menuAnnUngroup.Enabled = false;
            this.menuAnnUngroup.Index = 14;
            this.menuAnnUngroup.Text = "&Ungroup";
            this.menuAnnUngroup.Click += new System.EventHandler(this.menuAnnUngroup_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 15;
            this.menuItem11.Text = "-";
            // 
            // menuEnableClassyRenderers
            // 
            this.menuEnableClassyRenderers.Index = 16;
            this.menuEnableClassyRenderers.Text = "Enable Classy Renderers";
            this.menuEnableClassyRenderers.Click += new System.EventHandler(this.menuEnableClassyRenderers_Click);
            // 
            // menuAnnotationsTooltips
            // 
            this.menuAnnotationsTooltips.Index = 17;
            this.menuAnnotationsTooltips.Text = "Show Tooltips";
            this.menuAnnotationsTooltips.Click += new System.EventHandler(this.menuAnnotationsTooltips_Click);
            // 
            // menuInteractMode
            // 
            this.menuInteractMode.Index = 18;
            this.menuInteractMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuInteractModeNone,
            this.menuInteractModeAuthor,
            this.menuInteractModeView});
            this.menuInteractMode.Text = "Interact Mode";
            // 
            // menuInteractModeNone
            // 
            this.menuInteractModeNone.Index = 0;
            this.menuInteractModeNone.RadioCheck = true;
            this.menuInteractModeNone.Text = "None";
            this.menuInteractModeNone.Click += new System.EventHandler(this.menuInteractModeNone_Click);
            // 
            // menuInteractModeAuthor
            // 
            this.menuInteractModeAuthor.Index = 1;
            this.menuInteractModeAuthor.RadioCheck = true;
            this.menuInteractModeAuthor.Text = "Author";
            this.menuInteractModeAuthor.Click += new System.EventHandler(this.menuInteractModeAuthor_Click);
            // 
            // menuInteractModeView
            // 
            this.menuInteractModeView.Index = 2;
            this.menuInteractModeView.RadioCheck = true;
            this.menuInteractModeView.Text = "View";
            this.menuInteractModeView.Click += new System.EventHandler(this.menuInteractModeView_Click);
            // 
            // menuLayers
            // 
            this.menuLayers.Index = 3;
            this.menuLayers.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuLayersClear,
            this.menuLayersClearAll,
            this.menuItem3,
            this.menuLayersAdd,
            this.menuLayersRemove,
            this.menuItem8,
            this.menuLayersMoveToFront,
            this.menuLayersMoveUp,
            this.menuLayersMoveBack,
            this.menuLayersMoveToBack,
            this.menuItem10});
            this.menuLayers.Text = "&Layers";
            // 
            // menuLayersClear
            // 
            this.menuLayersClear.Index = 0;
            this.menuLayersClear.Text = "&Clear Current Layer";
            this.menuLayersClear.Click += new System.EventHandler(this.menuLayersClearLayer_Click);
            // 
            // menuLayersClearAll
            // 
            this.menuLayersClearAll.Index = 1;
            this.menuLayersClearAll.Text = "Clear All Layers";
            this.menuLayersClearAll.Click += new System.EventHandler(this.menuLayersClearAll_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // menuLayersAdd
            // 
            this.menuLayersAdd.Index = 3;
            this.menuLayersAdd.Text = "Add";
            this.menuLayersAdd.Click += new System.EventHandler(this.menuLayersAdd_Click);
            // 
            // menuLayersRemove
            // 
            this.menuLayersRemove.Index = 4;
            this.menuLayersRemove.Text = "Remove Current";
            this.menuLayersRemove.Click += new System.EventHandler(this.menuLayersRemove_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 5;
            this.menuItem8.Text = "-";
            // 
            // menuLayersMoveToFront
            // 
            this.menuLayersMoveToFront.Index = 6;
            this.menuLayersMoveToFront.Text = "Move To Front";
            this.menuLayersMoveToFront.Click += new System.EventHandler(this.menuLayersMove_Click);
            // 
            // menuLayersMoveUp
            // 
            this.menuLayersMoveUp.Index = 7;
            this.menuLayersMoveUp.Text = "Move Up";
            this.menuLayersMoveUp.Click += new System.EventHandler(this.menuLayersMove_Click);
            // 
            // menuLayersMoveBack
            // 
            this.menuLayersMoveBack.Index = 8;
            this.menuLayersMoveBack.Text = "Move Back";
            this.menuLayersMoveBack.Click += new System.EventHandler(this.menuLayersMove_Click);
            // 
            // menuLayersMoveToBack
            // 
            this.menuLayersMoveToBack.Index = 9;
            this.menuLayersMoveToBack.Text = "Move To Back";
            this.menuLayersMoveToBack.Click += new System.EventHandler(this.menuLayersMove_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 10;
            this.menuItem10.Text = "-";
            // 
            // menuSecurity
            // 
            this.menuSecurity.Index = 4;
            this.menuSecurity.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSecurityLockAnnotations,
            this.menuSecurityLockLayer,
            this.menuItem20,
            this.menuSecurityUnlockAnnotations,
            this.menuSecurityUnlockLayer,
            this.menuItem12,
            this.menuSecuritySelectImage,
            this.menuSecurityClearImage});
            this.menuSecurity.Text = "&Security";
            // 
            // menuSecurityLockAnnotations
            // 
            this.menuSecurityLockAnnotations.Index = 0;
            this.menuSecurityLockAnnotations.Text = "Lock Selected Annotations";
            this.menuSecurityLockAnnotations.Click += new System.EventHandler(this.menuSecurityLockAnnotations_Click);
            // 
            // menuSecurityLockLayer
            // 
            this.menuSecurityLockLayer.Index = 1;
            this.menuSecurityLockLayer.Text = "Lock Current Layer";
            this.menuSecurityLockLayer.Click += new System.EventHandler(this.menuSecurityLockLayer_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.Text = "-";
            // 
            // menuSecurityUnlockAnnotations
            // 
            this.menuSecurityUnlockAnnotations.Index = 3;
            this.menuSecurityUnlockAnnotations.Text = "Unlock Selected Annotations";
            this.menuSecurityUnlockAnnotations.Click += new System.EventHandler(this.menuSecurityUnlockAnnotations_Click);
            // 
            // menuSecurityUnlockLayer
            // 
            this.menuSecurityUnlockLayer.Index = 4;
            this.menuSecurityUnlockLayer.Text = "Unlock Current Layer";
            this.menuSecurityUnlockLayer.Click += new System.EventHandler(this.menuSecurityUnlockLayer_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 5;
            this.menuItem12.Text = "-";
            // 
            // menuSecuritySelectImage
            // 
            this.menuSecuritySelectImage.Index = 6;
            this.menuSecuritySelectImage.Text = "Select Locked Image";
            this.menuSecuritySelectImage.Click += new System.EventHandler(this.menuSecuritySelectImage_Click);
            // 
            // menuSecurityClearImage
            // 
            this.menuSecurityClearImage.Index = 7;
            this.menuSecurityClearImage.Text = "Clear Locked Image";
            this.menuSecurityClearImage.Click += new System.EventHandler(this.menuSecurityClearImage_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 5;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 0;
            this.menuHelpAbout.Text = "&About...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(80, 587);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusFile,
            this.statusInfo,
            this.statusPage,
            this.statusAnnCount,
            this.statusResolution});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(610, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusFile
            // 
            this.statusFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusFile.Name = "statusFile";
            this.statusFile.Text = "No File";
            this.statusFile.Width = 362;
            // 
            // statusInfo
            // 
            this.statusInfo.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Width = 10;
            // 
            // statusPage
            // 
            this.statusPage.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusPage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusPage.Name = "statusPage";
            this.statusPage.Text = "Page 0 of 0";
            this.statusPage.Width = 72;
            // 
            // statusAnnCount
            // 
            this.statusAnnCount.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusAnnCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusAnnCount.Name = "statusAnnCount";
            this.statusAnnCount.Text = "Annotations:  0";
            this.statusAnnCount.Width = 90;
            // 
            // statusResolution
            // 
            this.statusResolution.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusResolution.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusResolution.Name = "statusResolution";
            this.statusResolution.Text = "150px / Inch";
            this.statusResolution.Width = 76;
            // 
            // annotateViewer1
            // 
            this.annotateViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
            this.annotateViewer1.DefaultSecurity = null;
            this.annotateViewer1.DisplayProfile = null;
            this.annotateViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotateViewer1.Location = new System.Drawing.Point(80, 0);
            this.annotateViewer1.Magnifier.BackColor = System.Drawing.Color.White;
            this.annotateViewer1.Magnifier.BorderColor = System.Drawing.Color.Black;
            this.annotateViewer1.Magnifier.Size = new System.Drawing.Size(100, 100);
            this.annotateViewer1.Name = "annotateViewer1";
            this.annotateViewer1.OutputProfile = null;
            this.annotateViewer1.RotationSnapInterval = 0F;
            this.annotateViewer1.RotationSnapThreshold = 0F;
            this.annotateViewer1.Selection = null;
            this.annotateViewer1.Size = new System.Drawing.Size(610, 587);
            this.annotateViewer1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.annotateViewer1.TabIndex = 1;
            this.annotateViewer1.Text = "annotateViewer1";
            this.annotateViewer1.ToolTip = null;
            this.annotateViewer1.UndoManager.Levels = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(690, 0);
            this.splitter1.MinExtra = 200;
            this.splitter1.MinSize = 200;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 609);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelAnnotation);
            this.panelRight.Controls.Add(this.splitter2);
            this.panelRight.Controls.Add(this.panelLayer);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(696, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(200, 609);
            this.panelRight.TabIndex = 3;
            // 
            // panelAnnotation
            // 
            this.panelAnnotation.Controls.Add(this.propGridAnnotation);
            this.panelAnnotation.Controls.Add(this.lblActive);
            this.panelAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnnotation.Location = new System.Drawing.Point(0, 0);
            this.panelAnnotation.Name = "panelAnnotation";
            this.panelAnnotation.Size = new System.Drawing.Size(200, 379);
            this.panelAnnotation.TabIndex = 4;
            // 
            // propGridAnnotation
            // 
            this.propGridAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGridAnnotation.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propGridAnnotation.Location = new System.Drawing.Point(0, 24);
            this.propGridAnnotation.Name = "propGridAnnotation";
            this.propGridAnnotation.Size = new System.Drawing.Size(200, 355);
            this.propGridAnnotation.TabIndex = 6;
            // 
            // lblActive
            // 
            this.lblActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActive.Location = new System.Drawing.Point(0, 0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(200, 24);
            this.lblActive.TabIndex = 5;
            this.lblActive.Text = "Active Annotation";
            this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 379);
            this.splitter2.MinExtra = 100;
            this.splitter2.MinSize = 100;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(200, 6);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panelLayer
            // 
            this.panelLayer.Controls.Add(this.lblLayer);
            this.panelLayer.Controls.Add(this.propGridTemplate);
            this.panelLayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLayer.Location = new System.Drawing.Point(0, 385);
            this.panelLayer.Name = "panelLayer";
            this.panelLayer.Size = new System.Drawing.Size(200, 224);
            this.panelLayer.TabIndex = 2;
            // 
            // lblLayer
            // 
            this.lblLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLayer.Location = new System.Drawing.Point(0, 0);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(200, 24);
            this.lblLayer.TabIndex = 3;
            this.lblLayer.Text = "Annotation Template";
            this.lblLayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // propGridTemplate
            // 
            this.propGridTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGridTemplate.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propGridTemplate.Location = new System.Drawing.Point(0, 0);
            this.propGridTemplate.Name = "propGridTemplate";
            this.propGridTemplate.Size = new System.Drawing.Size(200, 224);
            this.propGridTemplate.TabIndex = 2;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbEllipse,
            this.tbFreehand,
            this.tbLine,
            this.tbLines,
            this.tbPolygon,
            this.tbRetangle,
            this.tbTriangle,
            this.tbTrianglePoint,
            this.tbArc,
            this.tbSpacer1,
            this.tbSep1,
            this.tbRectangleHighlighter,
            this.tbFreehandHighlighter,
            this.tbSep2,
            this.tbEmbeddedImage,
            this.tbReferencedImage,
            this.tbSep3,
            this.tbRectangleHotspot,
            this.tbFreehandHotspot,
            this.tbSep4,
            this.tbText,
            this.tbCallout,
            this.tbStickyNote,
            this.tbRubberStamp,
            this.tbRedaction,
            this.tbSpacer2,
            this.tbSep5,
            this.tbPdfMarkup,
            this.tbPdfLine});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.toolImageList;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(80, 609);
            this.toolBar1.TabIndex = 4;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbEllipse
            // 
            this.tbEllipse.Name = "tbEllipse";
            this.tbEllipse.ToolTipText = "Ellipse";
            // 
            // tbFreehand
            // 
            this.tbFreehand.Name = "tbFreehand";
            this.tbFreehand.ToolTipText = "Freehand";
            // 
            // tbLine
            // 
            this.tbLine.Name = "tbLine";
            this.tbLine.ToolTipText = "Line";
            // 
            // tbLines
            // 
            this.tbLines.Name = "tbLines";
            this.tbLines.ToolTipText = "Lines";
            // 
            // tbPolygon
            // 
            this.tbPolygon.Name = "tbPolygon";
            this.tbPolygon.ToolTipText = "Polygon";
            // 
            // tbRetangle
            // 
            this.tbRetangle.Name = "tbRetangle";
            this.tbRetangle.ToolTipText = "Rectangle";
            // 
            // tbTriangle
            // 
            this.tbTriangle.Name = "tbTriangle";
            this.tbTriangle.ToolTipText = "Triangle";
            // 
            // tbTrianglePoint
            // 
            this.tbTrianglePoint.Name = "tbTrianglePoint";
            this.tbTrianglePoint.ToolTipText = "TrianglePoint";
            // 
            // tbArc
            // 
            this.tbArc.Name = "tbArc";
            this.tbArc.ToolTipText = "Arc";
            // 
            // tbSpacer1
            // 
            this.tbSpacer1.Enabled = false;
            this.tbSpacer1.Name = "tbSpacer1";
            // 
            // tbSep1
            // 
            this.tbSep1.Name = "tbSep1";
            this.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbRectangleHighlighter
            // 
            this.tbRectangleHighlighter.Name = "tbRectangleHighlighter";
            this.tbRectangleHighlighter.ToolTipText = "Rectangle Highlighter";
            // 
            // tbFreehandHighlighter
            // 
            this.tbFreehandHighlighter.Name = "tbFreehandHighlighter";
            this.tbFreehandHighlighter.ToolTipText = "Freehand Highlighter";
            // 
            // tbSep2
            // 
            this.tbSep2.Name = "tbSep2";
            this.tbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbEmbeddedImage
            // 
            this.tbEmbeddedImage.Name = "tbEmbeddedImage";
            this.tbEmbeddedImage.ToolTipText = "Embedded Image";
            // 
            // tbReferencedImage
            // 
            this.tbReferencedImage.Name = "tbReferencedImage";
            this.tbReferencedImage.ToolTipText = "Referenced Image";
            // 
            // tbSep3
            // 
            this.tbSep3.Name = "tbSep3";
            this.tbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbRectangleHotspot
            // 
            this.tbRectangleHotspot.Name = "tbRectangleHotspot";
            this.tbRectangleHotspot.ToolTipText = "Rectangle Hotspot";
            // 
            // tbFreehandHotspot
            // 
            this.tbFreehandHotspot.Name = "tbFreehandHotspot";
            this.tbFreehandHotspot.ToolTipText = "Freehand Hotspot";
            // 
            // tbSep4
            // 
            this.tbSep4.Name = "tbSep4";
            this.tbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbText
            // 
            this.tbText.Name = "tbText";
            this.tbText.ToolTipText = "Text";
            // 
            // tbCallout
            // 
            this.tbCallout.Name = "tbCallout";
            this.tbCallout.ToolTipText = "Callout";
            // 
            // tbStickyNote
            // 
            this.tbStickyNote.Name = "tbStickyNote";
            this.tbStickyNote.ToolTipText = "Sticky Note";
            // 
            // tbRubberStamp
            // 
            this.tbRubberStamp.Name = "tbRubberStamp";
            this.tbRubberStamp.ToolTipText = "Rubber Stamp";
            // 
            // tbRedaction
            // 
            this.tbRedaction.Name = "tbRedaction";
            this.tbRedaction.ToolTipText = "Redaction";
            // 
            // tbSpacer2
            // 
            this.tbSpacer2.Enabled = false;
            this.tbSpacer2.Name = "tbSpacer2";
            // 
            // tbSep5
            // 
            this.tbSep5.Name = "tbSep5";
            this.tbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbPdfMarkup
            // 
            this.tbPdfMarkup.DropDownMenu = this.contextPdf;
            this.tbPdfMarkup.Name = "tbPdfMarkup";
            this.tbPdfMarkup.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbPdfMarkup.ToolTipText = "PDF Markup";
            // 
            // contextPdf
            // 
            this.contextPdf.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuPdfHighlight,
            this.menuPdfSquiggly,
            this.menuPdfStrikeOut,
            this.menuPdfUnderline});
            // 
            // menuPdfHighlight
            // 
            this.menuPdfHighlight.Index = 0;
            this.menuPdfHighlight.Text = "Highlight";
            this.menuPdfHighlight.Click += new System.EventHandler(this.menuAddPdfHighlighter_Click);
            // 
            // menuPdfSquiggly
            // 
            this.menuPdfSquiggly.Index = 1;
            this.menuPdfSquiggly.Text = "Squiggly";
            this.menuPdfSquiggly.Click += new System.EventHandler(this.menuAddPdfSquiggly_Click);
            // 
            // menuPdfStrikeOut
            // 
            this.menuPdfStrikeOut.Index = 2;
            this.menuPdfStrikeOut.Text = "Strike Out";
            this.menuPdfStrikeOut.Click += new System.EventHandler(this.menuAddPdfStrikeout_Click);
            // 
            // menuPdfUnderline
            // 
            this.menuPdfUnderline.Index = 3;
            this.menuPdfUnderline.Text = "Underline";
            this.menuPdfUnderline.Click += new System.EventHandler(this.menuAddPdfUnderline_Click);
            // 
            // tbPdfLine
            // 
            this.tbPdfLine.Name = "tbPdfLine";
            this.tbPdfLine.ToolTipText = "PDF Line";
            // 
            // toolImageList
            // 
            this.toolImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.toolImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.toolImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(896, 609);
            this.Controls.Add(this.annotateViewer1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelRight);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(512, 448);
            this.Name = "Form1";
            this.Text = "Atalasoft DotAnnotate Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.statusFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusAnnCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusResolution)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelAnnotation.ResumeLayout(false);
            this.panelLayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        #region File Menu

        private void menuExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void menuFileOpen_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (this._lastOpenDirectory != "")
            {
                dlg.InitialDirectory = this._lastOpenDirectory;
            }
            else
            {
                // try to locate images folder
                string imagesFolder = Application.ExecutablePath;
                // we assume we are running under the DotImage install folder
                int pos = imagesFolder.IndexOf("DotImage ");
                if (pos != -1)
                {
                    imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf(@"\", pos)) + @"\Images";
                }

                //use this folder as starting point			
                dlg.InitialDirectory = imagesFolder;
            }

            dlg.Filter = HelperMethods.CreateDialogFilter(true);

            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this._lastOpenDirectory = Path.GetDirectoryName(dlg.FileName);
                    this.annotateViewer1.Open(dlg.FileName, -1, true);
                    this.statusFile.Text = dlg.FileName;
                    this.statusPage.Text = "Page 1 of " + this.annotateViewer1.Images.Count.ToString();
                    this.statusResolution.Text = this.annotateViewer1.Resolution.ToString() + " / " + this.annotateViewer1.Units.ToString();
                    UpdateMenu();
                    UpdateLayerItemMenu();
                }
            }
            finally
            {
                dlg.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void menuFileSave_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "TIFF (*.tif)|*.tif|JPEG (*.jpg)|*.jpg" + (_pdfAnnotationSupport ? "|PDF (*.pdf)|*.pdf" : "");

            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (dlg.FilterIndex == 3)
                    {
                        // Pdf has to be handled a little differently.
                        this.annotateViewer1.Save(dlg.FileName, new Atalasoft.Imaging.Codec.Pdf.PdfEncoder());
                        SavePdfAnnotations(dlg.FileName);
                    }
                    else
                    {
                        ImageEncoder encoder = null;
                        if (dlg.FilterIndex == 1)
                            encoder = new TiffEncoder();
                        else if (dlg.FilterIndex == 2)
                            encoder = new JpegEncoder();

                        if (encoder != null)
                            this.annotateViewer1.Save(dlg.FileName, encoder as IAnnotationEncoder, -1, true);
                    }
                }
            }
            finally
            {
                dlg.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private void SavePdfAnnotations(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Atalasoft.Annotate.Exporters.PdfAnnotationDataExporter exp = new Atalasoft.Annotate.Exporters.PdfAnnotationDataExporter();

                // added by RS 2015/08/18 to ensure proper PDF embedding/round tripping
                exp.AlwaysEmbedAnnotationData = true;

                SizeF[] pageSizes = new SizeF[annotateViewer1.Images.Count];
                Dpi[] resolutions = new Dpi[annotateViewer1.Images.Count];

                for (int i = 0; i < annotateViewer1.Images.Count; i++)
                {
                    pageSizes[i] = annotateViewer1.Images[i].Size;
                    resolutions[i] = annotateViewer1.Images[i].Resolution;
                }

                LayerCollection layers = annotateViewer1.Annotations.Layers;
                AnnotationUnit units = annotateViewer1.Units;

                AnnotationDataCollection data = new AnnotationDataCollection();
                foreach (LayerAnnotation layer in layers)
                    data.Add(layer.Data);

                exp.ExportOver(fs, pageSizes, units, resolutions, data);
            }
        }

        private void menuFileNextPage_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Images.MoveNext();
            int index = this.annotateViewer1.Images.IndexOf(this.annotateViewer1.Image) + 1;
            this.statusPage.Text = "Page " + index.ToString() + " of " + this.annotateViewer1.Images.Count.ToString();
            this.statusResolution.Text = this.annotateViewer1.Resolution.ToString() + " / " + this.annotateViewer1.Units.ToString();

            // Update menu items.
            index--;
            UpdateNextPreviousMenus(index);
            UpdateLayerMenuItemIndex(index);
        }

        private void menuFilePreviousPage_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Images.MovePrevious();
            int index = this.annotateViewer1.Images.IndexOf(this.annotateViewer1.Image) + 1;
            this.statusPage.Text = "Page " + index.ToString() + " of " + this.annotateViewer1.Images.Count.ToString();
            this.statusResolution.Text = this.annotateViewer1.Resolution.ToString() + " / " + this.annotateViewer1.Units.ToString();

            // Update menu items.
            index--;
            UpdateNextPreviousMenus(index);
            UpdateLayerMenuItemIndex(index);
        }

        private void menuFilePrint_Click(object sender, System.EventArgs e)
        {
            Atalasoft.Annotate.UI.AnnotatePrintDocument doc = new AnnotatePrintDocument(this.annotateViewer1.Annotations, this.annotateViewer1.Images);
            doc.ScaleMode = Atalasoft.Imaging.WinControls.PrintScaleMode.FitToMargins;
            doc.Center = true;
            doc.Units = this.annotateViewer1.Units;

            using (PrintDialog dlg = new PrintDialog())
            {
                dlg.Document = doc;
                if (dlg.ShowDialog(this) == DialogResult.OK) doc.Print();
            }
            doc.Dispose();
        }

        private void menuFileBurn_Click(object sender, System.EventArgs e)
        {
            if (this.annotateViewer1.Image == null)
            {
                MessageBox.Show(this, "An image must be loaded into the viewer before you can use the burn feature.", "No Image Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_appSettings.BurnConvert)
            {
                // We are only burning the current image.
                // Because we can't get a Graphics object from an indexed image
                // we may need to convert it to 24-bit.
                if (this.annotateViewer1.Image.ColorDepth < 24)
                {
                    Atalasoft.Imaging.ImageProcessing.ChangePixelFormatCommand cmd = new Atalasoft.Imaging.ImageProcessing.ChangePixelFormatCommand(PixelFormat.Pixel24bppBgr);
                    this.annotateViewer1.ApplyCommand(cmd);

                }

                Bitmap bmp = this.annotateViewer1.Image.ToBitmap();
                this.annotateViewer1.Annotations.RenderAnnotations(new AnnotationImage(bmp));
                AtalaImage img = AtalaImage.FromBitmap(bmp);

                this.annotateViewer1.Image = img;
            }
            else
            {
                this.annotateViewer1.Burn();
                this.annotateViewer1.Refresh();
            }
        }

        private void menuFileRotate_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.RotateDocument(DocumentRotation.Rotate90);
        }

        private void menuZoom_Click(object sender, System.EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item == null) return;

            double zoom = double.Parse(item.Text.Replace("%", "")) / 100.0;
            this.annotateViewer1.Zoom = zoom;

            this.menuZoom100.Checked = false;
            this.menuZoom200.Checked = false;
            this.menuZoom25.Checked = false;
            this.menuZoom50.Checked = false;
            this.menuZoom500.Checked = false;
            item.Checked = true;
        }

        #endregion

        #region Annotations Menu

        private void menuAnnotationsLoad_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // WNG isn't a real extension for WANG annotations but we'll use it for our demo.
            dlg.Filter = "XMP (*.xml)|*.xml|WANG (*.wng)|*.wng|Binary (*.bin)|*.bin";

            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (this.annotateViewer1.Annotations.Layers.Count == 0)
                        this.annotateViewer1.Annotations.Layers.Add(new LayerAnnotation());

                    using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        if (dlg.FilterIndex == 3)
                        {
                            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            bf.Binder = new CustomDataBinder();
                            this.annotateViewer1.Annotations.Load(fs, this.annotateViewer1.Annotations.CurrentLayer, bf);
                        }
                        else
                            this.annotateViewer1.Annotations.Load(fs, this.annotateViewer1.Annotations.CurrentLayer, (dlg.FilterIndex == 1 ? AnnotationDataFormat.Xmp : AnnotationDataFormat.Wang));
                    }
                    UpdateMenu();
                    UpdateLayerItemMenu();
                }
            }
            finally
            {
                dlg.Dispose();
            }

        }

        private void menuAnnotationsSave_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XMP (*.xml)|*.xml|WANG (*.wng)|*.wng|Binary (*.bin)|*.bin";

            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        if (dlg.FilterIndex == 3)
                        {
                            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            this.annotateViewer1.Annotations.Save(fs, bf);
                        }
                        else
                            this.annotateViewer1.Annotations.Save(fs, (dlg.FilterIndex == 1 ? AnnotationDataFormat.Xmp : AnnotationDataFormat.Wang));
                    }
                }
            }
            finally
            {
                dlg.Dispose();
            }
        }

        private void menuAnnotationsRemove_Click(object sender, System.EventArgs e)
        {
            if (this.annotateViewer1.Annotations.ActiveAnnotation != null)
            {
                this.propGridAnnotation.SelectedObject = null;

                AnnotationUI[] annotations = this.annotateViewer1.Annotations.SelectedAnnotations;
                foreach (AnnotationUI ann in annotations)
                {
                    ann.Remove();
                }

                UpdateMenu();
            }
        }

        private void menuAnnotationsMove_Click(object sender, System.EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item == null) return;

            // This will act on the activate annotation (if there is one).
            if (this.annotateViewer1.Annotations.ActiveAnnotation != null)
                MoveAnnotationObject(this.annotateViewer1.Annotations.ActiveAnnotation, item.Text);
        }

        private void menuFlipH_Click(object sender, System.EventArgs e)
        {
            if (this.annotateViewer1.Annotations.ActiveAnnotation != null)
                this.annotateViewer1.Annotations.ActiveAnnotation.Mirror(MirrorDirection.Horizontal, true);
        }

        private void menuFlipV_Click(object sender, System.EventArgs e)
        {
            if (this.annotateViewer1.Annotations.ActiveAnnotation != null)
                this.annotateViewer1.Annotations.ActiveAnnotation.Mirror(MirrorDirection.Vertical, true);
        }

        private void menuAnnotationsTooltips_Click(object sender, System.EventArgs e)
        {
            this.menuAnnotationsTooltips.Checked = !this.menuAnnotationsTooltips.Checked;
            if (this.menuAnnotationsTooltips.Checked)
                this.annotateViewer1.Annotations.ToolTip = this.toolTip1;
            else
                this.annotateViewer1.Annotations.ToolTip = null;
        }

        private void menuAnnGroup_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.Group();
            UpdateMenu();
        }

        private void menuAnnUngroup_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.Ungroup();
            UpdateMenu();
        }

        private void menuEnableClassyRenderers_Click(object sender, System.EventArgs e)
        {
            this.menuEnableClassyRenderers.Checked = !this.menuEnableClassyRenderers.Checked;
            if (this.menuEnableClassyRenderers.Checked)
                ClassyAnnotationRenderers.InstallClassyRenderers();
            else
                ClassyAnnotationRenderers.InstallDefaultRenderers();

            this.annotateViewer1.Refresh();
        }

        private void menuInteractModeNone_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.InteractMode = AnnotateInteractMode.None;
            UpdateInteractModeMenu();
            this.propGridAnnotation.SelectedObject = null;
        }

        private void menuInteractModeAuthor_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.InteractMode = AnnotateInteractMode.Author;
            UpdateInteractModeMenu();
        }

        private void menuInteractModeView_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.InteractMode = AnnotateInteractMode.View;
            UpdateInteractModeMenu();
            this.propGridAnnotation.SelectedObject = null;
        }

        private void UpdateInteractModeMenu()
        {
            this.menuInteractModeAuthor.Checked = false;
            this.menuInteractModeNone.Checked = false;
            this.menuInteractModeView.Checked = false;

            switch (this.annotateViewer1.Annotations.InteractMode)
            {
                case AnnotateInteractMode.None:
                    this.menuInteractModeNone.Checked = true;
                    break;
                case AnnotateInteractMode.Author:
                    this.menuInteractModeAuthor.Checked = true;
                    break;
                case AnnotateInteractMode.View:
                    this.menuInteractModeView.Checked = true;
                    break;
            }
        }

        #endregion

        #region Add Annotations

        private void AddNewAnnotation(AnnotationUI annotation)
        {
            if (annotation == null) return;

            this._templates.SetAnnotationDefaults(annotation);
            this.annotateViewer1.Annotations.CreateAnnotation(annotation, CreateAnnotationMode.Default);
        }

        private void menuAddCallout_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new CalloutAnnotation("", null, null, 2, null, null, new AnnotationPen(Color.Black), 20, PointF.Empty, true));
        }

        private void menuAddEllipse_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new EllipseAnnotation());
        }

        private string GetImageFileName()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.png;*.jpg;*.tif;*.gif;*.bmp";

            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }
            finally
            {
                dlg.Dispose();
            }

            return null;
        }

        private void menuAddEmbeddedImage_Click(object sender, System.EventArgs e)
        {
            string file = GetImageFileName();
            if (file == null) return;

            try
            {
                AddNewAnnotation(new EmbeddedImageAnnotation(new AnnotationImage(file), true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception creating an EmbeddedImageAnnotation\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuAddFreehand_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new FreehandAnnotation());
        }

        private void menuAddFreehandHotSpot_Click(object sender, System.EventArgs e)
        {
            HotSpotFreehandAnnotation hs = new HotSpotFreehandAnnotation(new AnnotationBrush(Color.DarkRed));
            this.annotateViewer1.Annotations.CreateAnnotation(hs);
        }

        private void menuAddHotSpot_Click(object sender, System.EventArgs e)
        {
            HotSpotAnnotation hs = new HotSpotAnnotation(RectangleF.Empty, new AnnotationBrush(Color.DarkRed));
            this.annotateViewer1.Annotations.CreateAnnotation(hs);
        }

        private void menuAddLine_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new LineAnnotation());
        }

        private void menuAddLines_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new LinesAnnotation());
        }

        private void menuAddPolygon_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new PolygonAnnotation());
        }

        private void menuAddRectangle_Click(object sender, System.EventArgs e)
        {
            RectangleAnnotation rc = new RectangleAnnotation();

            // Uncomment the following lines to test making 
            // the top-right grip used for rotation.
            //			rc.Grips[8].Visible = false;
            //			rc.Grips[2].Action = AnnotationGripAction.Rotating;

            AddNewAnnotation(rc);
        }

        private void menuAddReferencedImage_Click(object sender, System.EventArgs e)
        {
            string file = GetImageFileName();
            if (file == null) return;

            try
            {
                AddNewAnnotation(new ReferencedImageAnnotation(file, false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Exception creating a ReferencedImageAnnotation\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuAddRubberStamp_Click(object sender, System.EventArgs e)
        {
            RubberStampAnnotation rs = new RubberStampAnnotation();
            rs.Text = "DRAFT";
            this.annotateViewer1.Annotations.CreateAnnotation(rs, CreateAnnotationMode.Default);
        }

        private void menuAddText_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new TextAnnotation());
        }

        private void menuAddTriangle_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new TriangleAnnotation());
        }

        private void menuAddTrianglePoints_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new TrianglePointAnnotation());
        }

        #endregion

        #region Annotation Events

        private void Annotations_SelectionChanged(object sender, System.EventArgs e)
        {
            UpdatePropertyGridValues();
        }

        private void UpdatePropertyGridValues()
        {
            this.lblActive.Text = "Active Annotation";
            this.propGridAnnotation.SelectedObject = this.annotateViewer1.Annotations.ActiveAnnotation;
            UpdateMenu();
            if (this.annotateViewer1.Annotations.CurrentLayer == null)
                UpdateLayerMenuItemIndex(-1);
            else
                UpdateLayerMenuItemIndex(this.annotateViewer1.Annotations.Layers.IndexOf(this.annotateViewer1.Annotations.CurrentLayer));
        }

        private void Annotations_AnnotationCreated(object sender, AnnotationEventArgs e)
        {
            UpdateMenu();
            if (_layerMenus == null) UpdateLayerItemMenu();

            this.annotateViewer1.Annotations.ClearSelection();
            this.annotateViewer1.Annotations.ActiveAnnotation = e.Annotation;
            e.Annotation.Selected = true;
            UpdatePropertyGridValues();
        }

        private void Annotations_Rotating(object sender, AnnotationEventArgs e)
        {
            this.statusInfo.Text = "Rotating: " + e.Annotation.Data.Rotation.ToString();
        }

        private void Annotations_Moving(object sender, AnnotationEventArgs e)
        {
            this.statusInfo.Text = "Moving: " + e.Annotation.Data.Location.ToString();
        }

        private void Annotations_Resizing(object sender, AnnotationEventArgs e)
        {
            RectangleF rc = new RectangleF(e.Annotation.Location, e.Annotation.Size);
            this.statusInfo.Text = "Resizing: " + rc.X.ToString() + ", " + rc.Y.ToString() + ", " + rc.Width.ToString() + ", " + rc.Height.ToString();
        }

        private void Annotations_MovedResizedRotated(object sender, AnnotationEventArgs e)
        {
            this.statusInfo.Text = "";
            UpdateMenu();
        }

        #endregion

        #region Layers Menu

        private void menuLayersClearLayer_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.CurrentLayer.Items.Clear();
            this.propGridAnnotation.SelectedObject = null;
            UpdateMenu();
        }

        private void menuLayersClearAll_Click(object sender, System.EventArgs e)
        {
            foreach (LayerAnnotation layer in this.annotateViewer1.Annotations.Layers)
            {
                layer.Items.Clear();
            }

            this.propGridAnnotation.SelectedObject = null;
            UpdateMenu();
        }

        private void menuLayersMove_Click(object sender, System.EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item == null) return;
            MoveAnnotationObject(this.annotateViewer1.Annotations.CurrentLayer, item.Text);
            UpdateMenu();
            UpdateLayerItemMenu();
        }

        private void menuLayersAdd_Click(object sender, System.EventArgs e)
        {
            LayerAnnotation layer = new LayerAnnotation();

            // If we are in multipage mode add the layer as a child
            // of the current layer, otherwise add it as a top level layer.
            if (this.annotateViewer1.MultipageAnnotateMode)
            {
                LayerAnnotation topLayer = this.annotateViewer1.Annotations.GetTopLevelLayer(this.annotateViewer1.Annotations.CurrentLayer);
                if (topLayer == null)
                    topLayer.Items.Add(layer);
            }
            else
                this.annotateViewer1.Annotations.Layers.Add(layer);

            this.annotateViewer1.Annotations.CurrentLayer = layer;

            UpdateMenu();
            UpdateLayerItemMenu();
        }

        private void menuLayersRemove_Click(object sender, System.EventArgs e)
        {
            if (this.annotateViewer1.Annotations.CurrentLayer != null)
            {
                // In multipage mode, only allow child layers to be removed.
                if (this.annotateViewer1.MultipageAnnotateMode)
                {
                    if (this.annotateViewer1.Annotations.CurrentLayer.ParentLayer != null)
                        this.annotateViewer1.Annotations.CurrentLayer.Remove();
                }
                else
                    this.annotateViewer1.Annotations.Layers.Remove(this.annotateViewer1.Annotations.CurrentLayer);
            }

            UpdateMenu();
            UpdateLayerItemMenu();
        }

        private void OnLayerMenuItemClick(object sender, System.EventArgs e)
        {
            // This is called when a layer name is selected from the Layers menu.
            MenuItem item = sender as MenuItem;
            if (item == null) return;

            // Uncheck the current layer item.
            foreach (MenuItem mi in _layerMenus)
            {
                mi.Checked = false;
            }

            // Get the index from the menu text.
            int pos = item.Text.IndexOf(" ");
            if (pos == -1) pos = item.Text.Length;
            int index = -1;

            try
            {
                index = int.Parse(item.Text.Substring(0, pos));
            }
            catch
            {
                return;
            }

            if (this._appSettings.MultipageSupport)
            {
                this.annotateViewer1.Image = this.annotateViewer1.Images[index];
            }
            else
            {
                this.annotateViewer1.Annotations.CurrentLayer = this.annotateViewer1.Annotations.Layers[index];
            }

            item.Checked = true;
            UpdateNextPreviousMenus(index);
        }

        #endregion

        #region Help Menu

        private void menuHelpAbout_Click(object sender, System.EventArgs e)
        {
            AtalaDemos.AboutBox.About frm = new AtalaDemos.AboutBox.About("About...", "DotAnnotate Demo");
            frm.Description = "This demo provides example code for using Atalasoft DotAnnotate, along with DotImage, to read, write and modify annotations on images.";
            frm.ShowDialog(this);
            frm.Dispose();
        }

        #endregion

        #region Edit Menu

        private void menuEdit_Popup(object sender, System.EventArgs e)
        {
            if (this.annotateViewer1.Annotations.UndoManager.UndoCount == 0)
                this.menuEditUndo.Text = "&Undo";
            else
                this.menuEditUndo.Text = "&Undo " + this.annotateViewer1.Annotations.UndoManager.UndoDescription;

            if (this.annotateViewer1.Annotations.UndoManager.RedoCount == 0)
                this.menuEditRedo.Text = "&Redo";
            else
                this.menuEditRedo.Text = "&Redo " + this.annotateViewer1.Annotations.UndoManager.RedoDescription;
        }

        private void menuEditUndo_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.UndoManager.Undo();
            UpdateMenu();
            UpdateLayerItemMenu();
        }

        private void menuEditRedo_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.UndoManager.Redo();
            UpdateMenu();
            UpdateLayerItemMenu();
        }

        private void menuEditClearUndos_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.UndoManager.Clear();
            UpdateMenu();
        }

        private void menuEditCut_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.Cut();
            UpdateMenu();
        }

        private void menuEditCopy_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.Copy();
            UpdateMenu();
        }

        private void menuEditPaste_Click(object sender, System.EventArgs e)
        {
            this.annotateViewer1.Annotations.Paste();
            UpdateMenu();
        }

        private void menuEditSelectAll_Click(object sender, System.EventArgs e)
        {
            // We are only selecting annotations in the current layer.
            this.annotateViewer1.Annotations.SelectAll(false);
        }

        private void menuEditPreferences_Click(object sender, System.EventArgs e)
        {
            Preferences frm = new Preferences(_appSettings);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _appSettings = frm.Settings;
                ApplyAppSettings();
            }
            frm.Dispose();
        }

        #endregion

        #region Security Menu

        private void menuSecurityLockAnnotations_Click(object sender, System.EventArgs e)
        {
            AnnotationUI[] selected = this.annotateViewer1.Annotations.SelectedAnnotations;
            foreach (AnnotationUI ann in selected)
            {
                // We'll use the basic lock class.
                // For more control you can provide your own locking class.
                if (ann.Data.Security == null)
                    ann.Data.Security = new AnnotationLock();

                ann.Data.Security.Lock("Password");
            }
        }

        private void menuSecurityLockLayer_Click(object sender, System.EventArgs e)
        {
            LayerAnnotation layer = this.annotateViewer1.Annotations.CurrentLayer;
            if (layer == null) return;
            if (layer.Data.Security == null)
                layer.Data.Security = new AnnotationLock();

            layer.Data.Security.Lock("Password");
        }

        private void menuSecurityUnlockAnnotations_Click(object sender, System.EventArgs e)
        {
            AnnotationUI[] selected = this.annotateViewer1.Annotations.SelectedAnnotations;
            foreach (AnnotationUI ann in selected)
            {
                if (ann.Data.Security == null) continue;
                ann.Data.Security.Unlock("Password");
            }
        }

        private void menuSecurityUnlockLayer_Click(object sender, System.EventArgs e)
        {
            LayerAnnotation layer = this.annotateViewer1.Annotations.CurrentLayer;
            if (layer == null) return;
            if (layer.Data.Security == null) return;
            layer.Data.Security.Unlock("Password");
        }

        private void menuSecuritySelectImage_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images|*.jpg;*.gif;*.png;*.tif;*.bmp";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        AnnotationImage img = new AnnotationImage(dlg.FileName);
                        AnnotationUI[] selected = this.annotateViewer1.Annotations.SelectedAnnotations;
                        foreach (AnnotationUI ann in selected)
                        {
                            if (ann.Data.Security == null)
                                ann.Data.Security = new AnnotationLock();
                            ann.Data.Security.LockedImage = img.Clone();
                        }
                        img.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading security image.\r\n" + ex.Message);
                    }
                }
            }
        }

        private void menuSecurityClearImage_Click(object sender, System.EventArgs e)
        {
            AnnotationUI[] selected = this.annotateViewer1.Annotations.SelectedAnnotations;
            foreach (AnnotationUI ann in selected)
            {
                if (ann.Data.Security == null) continue;
                ann.Data.Security.LockedImage = null;
            }
        }

        #endregion

        #region Private Methods

        private void PopulateToolbox()
        {
            // Use the resource images in DotAnnotate for the tools.
            // Note: This order needs to match the order in the toolbar object.

            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Ellipse, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Freehand, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Line, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Lines, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Polygon, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Rectangle, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(DotAnnotateDemo.Properties.Resources.Triangle.ToBitmap());
            this.toolImageList.Images.Add(DotAnnotateDemo.Properties.Resources.TrianglePoint.ToBitmap());
            this.toolImageList.Images.Add(DotAnnotateDemo.Properties.Resources.Arc.ToBitmap());
            // Separator
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.RectangleHighlighter, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.FreehandHighlighter, AnnotateIconSize.Size32));
            // Separator
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.EmbeddedImage, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.ReferencedImage, AnnotateIconSize.Size32));
            // Separator
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.RectangleHotspot, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.FreehandHotspot, AnnotateIconSize.Size32));
            // Separator
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Text, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Callout, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.StickyNote, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.RubberStamp, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.Redact, AnnotateIconSize.Size32));
            // Separator
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.PdfMarkup, AnnotateIconSize.Size32));
            this.toolImageList.Images.Add(FixImageBackground(AnnotateIcon.PdfLine, AnnotateIconSize.Size32));

            int imgIndex = 0;
            for (int i = 0; i < 29; i++)
            {
                // Skip the separators and spacers.
                if (i == 9 || i == 10 || i == 13 || i == 16 || i == 19 || i == 25 || i == 26)
                    continue;

                this.toolBar1.Buttons[i].ImageIndex = imgIndex;
                imgIndex++;
            }

        }

        private System.Drawing.Image FixImageBackground(AnnotateIcon icon, AnnotateIconSize size)
		{
            // 2012-12-31 rsale - Added protection for null images - if we're handed a null
            // we will return a white 32pxx32px square
            Image image = IconResource.ExtractAnnotationIcon(icon, size);

            if (image == null)
            {
                Assembly assm = Assembly.LoadFrom(@"Atalasoft.dotImage.dll");
                if (assm != null)
                {
                    System.IO.Stream stream = assm.GetManifestResourceStream("Atalasoft.Imaging.Annotate.Icons._" + size.ToString().Substring(4) + "." + icon.ToString() + ".png");
                    image = System.Drawing.Image.FromStream(stream);
                }
                if (image == null)
                {
                    if (size.ToString() == "size16")
                        return new AtalaImage(16, 16, PixelFormat.Pixel24bppBgr, Color.White).ToBitmap();
                    if (size.ToString() == "size24")
                        return new AtalaImage(24, 24, PixelFormat.Pixel24bppBgr, Color.White).ToBitmap();
                    if (size.ToString() == "size32")
                        return new AtalaImage(32, 32, PixelFormat.Pixel24bppBgr, Color.White).ToBitmap();
                }
            }
            Atalasoft.Imaging.AtalaImage ai = Atalasoft.Imaging.AtalaImage.FromBitmap(image as System.Drawing.Bitmap);
            image.Dispose();

            Atalasoft.Imaging.ImageProcessing.Channels.FlattenAlphaCommand cmd = new Atalasoft.Imaging.ImageProcessing.Channels.FlattenAlphaCommand(this.BackColor);
            Atalasoft.Imaging.ImageProcessing.ImageResults results = cmd.Apply(ai);
            if (!results.IsImageSourceImage)
            {
                ai.Dispose();
                ai = results.Image;
            }

            image = ai.ToBitmap();
            ai.Dispose();
                return image;
            
            
		}

        private void ApplyAppSettings()
        {
            if (_appSettings == null)
            {
                string settingsDir = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Atalasoft\\Demos";
                if (!Directory.Exists(settingsDir))
                    Directory.CreateDirectory(settingsDir);
                _appSettings = new ApplicationPreferences(settingsDir + "\\DotAnnotateDemo_Preferences.xml", _templates);
            }

            this.annotateViewer1.KeyBinder[_appSettings.KeyIncreaseHeight] = new AnnotationKey(AnnotationKeyAction.IncreaseHeight);
            this.annotateViewer1.KeyBinder[_appSettings.KeyDecreaseHeight] = new AnnotationKey(AnnotationKeyAction.DecreaseHeight);
            this.annotateViewer1.KeyBinder[_appSettings.KeyIncreaseWidth] = new AnnotationKey(AnnotationKeyAction.IncreaseWidth);
            this.annotateViewer1.KeyBinder[_appSettings.KeyDecreaseWidth] = new AnnotationKey(AnnotationKeyAction.DecreaseWidth);
            this.annotateViewer1.KeyBinder[_appSettings.KeyMoveUp] = new AnnotationKey(AnnotationKeyAction.MoveUp);
            this.annotateViewer1.KeyBinder[_appSettings.KeyMoveLeft] = new AnnotationKey(AnnotationKeyAction.MoveLeft);
            this.annotateViewer1.KeyBinder[_appSettings.KeyMoveRight] = new AnnotationKey(AnnotationKeyAction.MoveRight);
            this.annotateViewer1.KeyBinder[_appSettings.KeyMoveDown] = new AnnotationKey(AnnotationKeyAction.MoveDown);
            this.annotateViewer1.KeyBinder[_appSettings.KeyRotateCounterclockwise] = new AnnotationKey(AnnotationKeyAction.RotateCounterclockwise);
            this.annotateViewer1.KeyBinder[_appSettings.KeyRotateClockwise] = new AnnotationKey(AnnotationKeyAction.RotateClockwise);
            this.annotateViewer1.KeyBinder[_appSettings.KeySelectAbove] = new AnnotationKey(AnnotationKeyAction.SelectAbove);
            this.annotateViewer1.KeyBinder[_appSettings.KeySelectLeft] = new AnnotationKey(AnnotationKeyAction.SelectLeft);
            this.annotateViewer1.KeyBinder[_appSettings.KeySelectRight] = new AnnotationKey(AnnotationKeyAction.SelectRight);
            this.annotateViewer1.KeyBinder[_appSettings.KeySelectBelow] = new AnnotationKey(AnnotationKeyAction.SelectBelow);
            this.annotateViewer1.KeyBinder[_appSettings.KeySelectPrevious] = new AnnotationKey(AnnotationKeyAction.SelectPrevious);
            this.annotateViewer1.KeyBinder[_appSettings.KeySelectNext] = new AnnotationKey(AnnotationKeyAction.SelectNext);
            this.annotateViewer1.KeyBinder[_appSettings.KeyClearSelection] = new AnnotationKey(AnnotationKeyAction.ClearSelection);

            this.annotateViewer1.AnnotationConfinement = _appSettings.Confinement;
            this.annotateViewer1.SmoothingMode = _appSettings.Smoothing;
            this.annotateViewer1.MultipageAnnotateMode = _appSettings.MultipageSupport;
            this.annotateViewer1.MultiSelectKey = _appSettings.MultiSelectKey;
            this.annotateViewer1.Units = _appSettings.Units;
            this.annotateViewer1.RotationSnapInterval = _appSettings.RotationSnapInterval;
            this.annotateViewer1.RotationSnapThreshold = _appSettings.RotationSnapThreshold;

            UpdateMenu();
            this.statusResolution.Text = this.annotateViewer1.Resolution.ToString() + " / " + this.annotateViewer1.Units.ToString();
        }

        private void MoveAnnotationObject(AnnotationUI annotation, string method)
        {
            switch (method)
            {
                case "Move To Back":
                    this.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveToBack);
                    break;
                case "Move Back":
                    this.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveBack);
                    break;
                case "Move Up":
                    this.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveUp);
                    break;
                case "Move To Front":
                    this.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveToFront);
                    break;
            }

            UpdateMenu();
        }

        private void UpdateMenu()
        {
            bool fileLoaded = (this.annotateViewer1.Image != null);
            int count = (fileLoaded ? this.annotateViewer1.Images.Count : 0);
            this.menuFileSave.Enabled = fileLoaded;
            this.menuFileNextPage.Enabled = (fileLoaded && this.annotateViewer1.Images.IndexOf(this.annotateViewer1.Image) < count - 1);
            this.menuFilePreviousPage.Enabled = (fileLoaded && this.annotateViewer1.Images.IndexOf(this.annotateViewer1.Image) > 0);
            this.menuFilePrint.Enabled = fileLoaded;
            this.menuZoom.Enabled = fileLoaded;
            this.menuFileRotate.Enabled = fileLoaded;

            int totalAnnotationCount = this.annotateViewer1.Annotations.CountAnnotations();
            this.statusAnnCount.Text = "Annotations: " + totalAnnotationCount.ToString();
            this.menuFileBurn.Enabled = (fileLoaded && totalAnnotationCount > 0);
            int selCount = this.annotateViewer1.Annotations.SelectedAnnotations.Length;
            this.menuAnnotationsSave.Enabled = (totalAnnotationCount > 0);

            AnnotationUI active = this.annotateViewer1.Annotations.ActiveAnnotation;
            bool activeItem = (active != null);
            this.menuAnnotationsRemove.Enabled = activeItem;
            this.menuAnnotationsFlip.Enabled = activeItem;

            this.menuEditUndo.Enabled = (this.annotateViewer1.Annotations.UndoManager.UndoCount > 0);
            this.menuEditRedo.Enabled = (this.annotateViewer1.Annotations.UndoManager.RedoCount > 0);
            this.menuEditCopy.Enabled = activeItem;
            this.menuEditCut.Enabled = activeItem;
            this.menuEditPaste.Enabled = this.annotateViewer1.Annotations.CanPaste();
            this.menuEditSelectAll.Enabled = (totalAnnotationCount > 0 && selCount < totalAnnotationCount);

            LayerAnnotation layer = active as LayerAnnotation;
            this.menuAnnGroup.Enabled = selCount > 1;
            this.menuAnnUngroup.Enabled = (selCount == 1 && layer != null && layer.GroupAnnotation);

            if (activeItem && active.ParentLayer != null)
            {
                int activeIndex = active.ParentLayer.Items.IndexOf(active);
                int alCount = active.ParentLayer.Items.Count;
                this.menuAnnotationsMoveToBack.Enabled = (activeIndex > 0);
                this.menuAnnotationsMoveToFront.Enabled = (activeIndex < alCount - 1);
                this.menuAnnotationsMoveBack.Enabled = this.menuAnnotationsMoveToBack.Enabled;
                this.menuAnnotationsMoveUp.Enabled = this.menuAnnotationsMoveToFront.Enabled;
            }
            else
            {
                this.menuAnnotationsMoveBack.Enabled = false;
                this.menuAnnotationsMoveToBack.Enabled = false;
                this.menuAnnotationsMoveToFront.Enabled = false;
                this.menuAnnotationsMoveUp.Enabled = false;
            }

            if (this.annotateViewer1.MultipageAnnotateMode && (this.annotateViewer1.Annotations.CurrentLayer == null || this.annotateViewer1.Annotations.CurrentLayer.ParentLayer == null))
            {
                this.menuLayersAdd.Enabled = false;
                this.menuLayersClear.Enabled = false;
                this.menuLayersClearAll.Enabled = false;
                this.menuLayersMoveBack.Enabled = false;
                this.menuLayersMoveToBack.Enabled = false;
                this.menuLayersMoveToFront.Enabled = false;
                this.menuLayersMoveUp.Enabled = false;
                this.menuLayersRemove.Enabled = false;
            }
            else
            {
                int layerCount = this.annotateViewer1.Annotations.Layers.Count;
                LayerAnnotation currentLayer = this.annotateViewer1.Annotations.CurrentLayer;
                bool childLayer = (currentLayer != null && currentLayer.ParentLayer != null);
                this.menuLayersAdd.Enabled = true;
                this.menuLayersClear.Enabled = (layerCount > 0);
                this.menuLayersClearAll.Enabled = (layerCount > 0);
                if (this.annotateViewer1.MultipageAnnotateMode)
                    this.menuLayersRemove.Enabled = childLayer;
                else
                    this.menuLayersRemove.Enabled = (currentLayer != null);
                if (layerCount < 2 || currentLayer == null)
                {
                    this.menuLayersMoveBack.Enabled = false;
                    this.menuLayersMoveToBack.Enabled = false;
                    this.menuLayersMoveUp.Enabled = false;
                    this.menuLayersMoveToFront.Enabled = false;
                }
                else if (currentLayer != null)
                {
                    int layerIndex = this.annotateViewer1.Annotations.Layers.IndexOf(currentLayer);
                    this.menuLayersMoveToFront.Enabled = (layerIndex < layerCount - 1);
                    this.menuLayersMoveToBack.Enabled = (layerIndex > 0);
                    this.menuLayersMoveBack.Enabled = this.menuLayersMoveToBack.Enabled;
                    this.menuLayersMoveUp.Enabled = this.menuLayersMoveToFront.Enabled;
                }
            }
        }

        private void UpdateLayerItemMenu()
        {
            // Add/Remove items in the Layers menu.
            if (_layerMenus != null)
            {
                foreach (MenuItem mi in _layerMenus)
                {
                    this.menuLayers.MenuItems.Remove(mi);
                    mi.Dispose();
                }

                _layerMenus = null;
            }

            int layerCount = this.annotateViewer1.Annotations.Layers.Count;
            if (layerCount > 0)
            {
                _layerMenus = new MenuItem[layerCount];
                for (int i = 0; i < layerCount; i++)
                {
                    LayerAnnotation layer = this.annotateViewer1.Annotations.Layers[i];
                    MenuItem item = new MenuItem(i.ToString() + (layer.Data.Name == null ? "" : layer.Data.Name), new EventHandler(OnLayerMenuItemClick));
                    item.RadioCheck = true;
                    if (i == 0) item.Checked = true;
                    _layerMenus[i] = item;
                }

                this.menuLayers.MenuItems.AddRange(_layerMenus);
            }
        }

        private void UpdateLayerMenuItemIndex(int index)
        {
            if (index < 0 || _layerMenus == null || index > _layerMenus.Length - 1)
                return;

            foreach (MenuItem mi in _layerMenus)
            {
                mi.Checked = false;
            }

            _layerMenus[index].Checked = true;
        }

        private void UpdateNextPreviousMenus(int index)
        {
            this.menuFileNextPage.Enabled = index < this.annotateViewer1.Images.Count - 1;
            this.menuFilePreviousPage.Enabled = index > 0;
        }

        #endregion

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_appSettings != null) _appSettings.Save();
        }

        private void propGridAnnotation_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateMenu();
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.ToolTipText)
            {
                case "Callout":
                    AddNewAnnotation(new CalloutAnnotation());
                    break;
                case "Ellipse":
                    AddNewAnnotation(new EllipseAnnotation());
                    break;
                case "Freehand":
                    AddNewAnnotation(new FreehandAnnotation());
                    break;
                case "Freehand Highlighter":
                    FreehandAnnotation fa = new FreehandAnnotation(new AnnotationPen(Color.Yellow, 10));
                    fa.Translucent = true;
                    this.annotateViewer1.Annotations.CreateAnnotation(fa);
                    break;
                case "Line":
                    AddNewAnnotation(new LineAnnotation());
                    break;
                case "Lines":
                    AddNewAnnotation(new LinesAnnotation());
                    break;
                case "Polygon":
                    AddNewAnnotation(new PolygonAnnotation());
                    break;
                case "Rectangle":
                    AddNewAnnotation(new RectangleAnnotation());
                    break;
                case "Triangle":
                    AddNewAnnotation(new TriangleAnnotation());
                    break;
                case "TrianglePoint":
                    TrianglePointAnnotation tri = new TrianglePointAnnotation();
                    tri.Fill = new AnnotationBrush(Color.DarkRed);
                    AddNewAnnotation(tri);
                    break;
                case "Arc":
                    ArcAnnotation arc = new ArcAnnotation();
                    arc.Fill = new AnnotationBrush(Color.DarkRed);
                    AddNewAnnotation(arc);
                    break;
                case "Rectangle Highlighter":
                    RectangleAnnotation ra = new RectangleAnnotation(new AnnotationBrush(Color.Yellow), null);
                    ra.Translucent = true;
                    this.annotateViewer1.Annotations.CreateAnnotation(ra);
                    break;
                case "Redaction":
                    RectangleAnnotation red = new RectangleAnnotation(new AnnotationBrush(Color.Black), null);
                    this.annotateViewer1.Annotations.CreateAnnotation(red);
                    break;
                case "Rubber Stamp":
                    RubberStampAnnotation rub = new RubberStampAnnotation("DRAFT");
                    rub.Size = new SizeF(300, 100);
                    rub.Data.Rotation = 326;
                    this.annotateViewer1.Annotations.CreateAnnotation(rub, CreateAnnotationMode.SingleClickCenter);
                    break;
                case "Sticky Note":
                    TextAnnotation ta = new TextAnnotation("Sticky Note: ", this._templates.Font, new AnnotationBrush(Color.Black), new AnnotationBrush(Color.Yellow), new AnnotationPen(Color.Black), new AnnotationBrush(Color.FromArgb(128, Color.Silver)), new PointF(8, 8), ShadowMode.Annotation);
                    ta.Size = new SizeF(200, 140);
                    this.annotateViewer1.Annotations.CreateAnnotation(ta, CreateAnnotationMode.SingleClickCenter);
                    break;
                case "Text":
                    AddNewAnnotation(new TextAnnotation());
                    break;
                case "Rectangle Hotspot":
                    HotSpotAnnotation hs = new HotSpotAnnotation(RectangleF.Empty, new AnnotationBrush(Color.DarkRed));
                    this.annotateViewer1.Annotations.CreateAnnotation(hs);
                    break;
                case "Freehand Hotspot":
                    HotSpotFreehandAnnotation fhs = new HotSpotFreehandAnnotation(new AnnotationBrush(Color.DarkRed));
                    this.annotateViewer1.Annotations.CreateAnnotation(fhs);
                    break;
                case "Embedded Image":
                case "Referenced Image":
                    string file = GetImageFileName();
                    if (file == null) return;

                    try
                    {
                        if (e.Button.ToolTipText == "Embedded Image")
                            AddNewAnnotation(new EmbeddedImageAnnotation(new AnnotationImage(file), true));
                        else
                            AddNewAnnotation(new ReferencedImageAnnotation(file, false));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Exception creating a ReferencedImageAnnotation\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case "PDF Markup":
                    // Use the last PDF annotation created, or underline.
                    if (_lastPdfAnnotation == null)
                        AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Underline);
                    else if (_lastPdfAnnotation.MarkupType == Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight)
                        this.annotateViewer1.Annotations.CreateAnnotation(_lastPdfAnnotation.Clone(), CreateAnnotationMode.Default);
                    else
                        AddNewAnnotation(_lastPdfAnnotation.Clone());
                    break;
                case "PDF Line":
                    AddNewAnnotation(new Atalasoft.Annotate.Pdf.PdfLineAnnotation());
                    break;
            }
        }

        #region PDF Annotations

        private void AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType markup)
        {
            switch (markup)
            {
                case Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight:
                    _lastPdfAnnotation = new Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(null, Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight);
                    _lastPdfAnnotation.Fill = new AnnotationBrush(Color.Yellow);
                    this.annotateViewer1.Annotations.CreateAnnotation(_lastPdfAnnotation.Clone(), CreateAnnotationMode.Default);
                    return;
                case Atalasoft.Annotate.Pdf.PdfMarkupType.Squiggly:
                    _lastPdfAnnotation = new Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(null, Atalasoft.Annotate.Pdf.PdfMarkupType.Squiggly);
                    if (this.annotateViewer1.Units != AnnotationUnit.Pixel)
                        _lastPdfAnnotation.SquigglyHeight = 4 * (1f / this.annotateViewer1.Resolution.X);
                    break;
                case Atalasoft.Annotate.Pdf.PdfMarkupType.StrikeOut:
                    _lastPdfAnnotation = new Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(null, Atalasoft.Annotate.Pdf.PdfMarkupType.StrikeOut);
                    break;
                case Atalasoft.Annotate.Pdf.PdfMarkupType.Underline:
                    _lastPdfAnnotation = new Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(null, Atalasoft.Annotate.Pdf.PdfMarkupType.Underline);
                    break;
            }

            AddNewAnnotation(_lastPdfAnnotation.Clone());
        }

        private void menuAddPdfLine_Click(object sender, System.EventArgs e)
        {
            AddNewAnnotation(new Atalasoft.Annotate.Pdf.PdfLineAnnotation());
        }

        private void menuAddPdfHighlighter_Click(object sender, System.EventArgs e)
        {
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight);
        }

        private void menuAddPdfSquiggly_Click(object sender, System.EventArgs e)
        {
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Squiggly);
        }

        private void menuAddPdfStrikeout_Click(object sender, System.EventArgs e)
        {
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.StrikeOut);
        }

        private void menuAddPdfUnderline_Click(object sender, System.EventArgs e)
        {
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Underline);
        }

        #endregion

    }
}
