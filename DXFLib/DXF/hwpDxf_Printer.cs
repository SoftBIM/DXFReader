using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class hwpDxf_Printer
	{
		private struct OSVERSIONINFO
		{
			public int dwOSVersionInfoSize;

			public int dwMajorVersion;

			public int dwMinorVersion;

			public int dwBuildNumber;

			public int dwPlatformId;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			[VBFixedString(128)]
			public char[] szCSDVersion;
		}

		private struct DEVMODE
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			[VBFixedString(32)]
			public char[] dmDeviceName;

			public short dmSpecVersion;

			public short dmDriverVersion;

			public short dmSize;

			public short dmDriverExtra;

			public int dmFields;

			public short dmOrientation;

			public short dmPaperSize;

			public short dmPaperLength;

			public short dmPaperWidth;

			public short dmScale;

			public short dmCopies;

			public short dmDefaultSource;

			public short dmPrintQuality;

			public short dmColor;

			public short dmDuplex;

			public short dmYResolution;

			public short dmTTOption;

			public short dmCollate;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			[VBFixedString(32)]
			public char[] dmFormName;

			public short dmUnusedPadding;

			public int dmBitsPerPel;

			public int dmPelsWidth;

			public int dmPelsHeight;

			public int dmDisplayFlags;

			public int dmDisplayFrequency;
		}

		private struct ACL
		{
			public byte AclRevision;

			public byte Sbz1;

			public short AclSize;

			public short AceCount;

			public short Sbz2;
		}

		private struct SECURITY_DESCRIPTOR
		{
			public byte Revision;

			public byte Sbz1;

			public int Control;

			public int Owner;

			public int Group;

			public ACL Sacl;

			public ACL Dacl;
		}

		private struct PRINTER_INFO_1
		{
			public int Flags;

			public int pDescription;

			public int pName;

			public int pComment;
		}

		private struct PRINTER_INFO_2
		{
			public int pServerName;

			public int pPrinterName;

			public int pShareName;

			public int pPortName;

			public int pDriverName;

			public int pComment;

			public int pLocation;

			public DEVMODE pDevMode;

			public int pSepFile;

			public int pPrintProcessor;

			public int pDatatype;

			public int pParameters;

			public SECURITY_DESCRIPTOR pSecurityDescriptor;

			public int Attributes;

			public int Priority;

			public int DefaultPriority;

			public int StartTime;

			public int UntilTime;

			public int Status;

			public int cJobs;

			public int AveragePPM;
		}

		private struct PRINTER_INFO_4
		{
			public int pPrinterName;

			public int pServerName;

			public int Attributes;
		}

		private struct PRINTER_INFO_5
		{
			public int pPrinterName;

			public int pPortName;

			public int Attributes;

			public int DeviceNotSelectedTimeout;

			public int TransmissionRetryTimeout;
		}

		private const short CCHDEVICENAME = 32;

		private const short CCHFORMNAME = 32;

		private const short VER_PLATFORM_WIN32_NT = 2;

		private const short VER_PLATFORM_WIN32_WINDOWS = 1;

		private const short VER_PLATFORM_WIN32s = 0;

		private const short PRINTER_ENUM_DEFAULT = 1;

		private const short PRINTER_ENUM_LOCAL = 2;

		private const short PRINTER_ENUM_CONNECTIONS = 4;

		private const short PRINTER_ENUM_NAME = 8;

		private const short PRINTER_ENUM_REMOTE = 16;

		private const short PRINTER_ENUM_SHARED = 32;

		private const short PRINTER_ENUM_NETWORK = 64;

		private const short PRINTER_LEVEL1 = 1;

		private const short PRINTER_LEVEL2 = 2;

		private const short PRINTER_LEVEL4 = 4;

		private const short PRINTER_LEVEL5 = 5;

		private const short SIZEOFPRINTER_INFO_1 = 16;

		private const short SIZEOFPRINTER_INFO_2 = 84;

		private const short SIZEOFPRINTER_INFO_4 = 12;

		private const short SIZEOFPRINTER_INFO_5 = 20;

		private const short PRINTER_ATTRIBUTE_QUEUED = 1;

		private const short PRINTER_ATTRIBUTE_DIRECT = 2;

		private const short PRINTER_ATTRIBUTE_DEFAULT = 4;

		private const short PRINTER_ATTRIBUTE_SHARED = 8;

		private const short PRINTER_ATTRIBUTE_NETWORK = 16;

		private const short PRINTER_ATTRIBUTE_HIDDEN = 32;

		private const short PRINTER_ATTRIBUTE_LOCAL = 64;

		private const short PRINTER_ATTRIBUTE_UNKNOWN1 = 128;

		private const short PRINTER_ATTRIBUTE_UNKNOWN2 = 256;

		private const short PRINTER_ATTRIBUTE_UNKNOWN3 = 512;

		private const short PRINTER_ATTRIBUTE_WORK_OFFLINE = 1024;

		private const short PRINTER_ATTRIBUTE_ENABLE_BIDI = 2048;

		private const short PRINTER_ENUM_EXPAND = 16384;

		private const short PRINTER_ENUM_CONTAINER = short.MinValue;

		private const int PRINTER_ENUM_ICON1 = 65536;

		private const int PRINTER_ENUM_ICON2 = 131072;

		private const int PRINTER_ENUM_ICON3 = 262144;

		private const int PRINTER_ENUM_ICON4 = 524288;

		private const int PRINTER_ENUM_ICON5 = 1048576;

		private const int PRINTER_ENUM_ICON6 = 2097152;

		private const int PRINTER_ENUM_ICON7 = 4194304;

		private const int PRINTER_ENUM_ICON8 = 8388608;

		private static OSVERSIONINFO $STATIC$BkDXFPrinter_IsWinNT$002$stypOS;

	private static bool $STATIC$BkDXFPrinter_IsWinNT$002$sblnIsWinNT;

	[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetVersionExA", ExactSpelling = true, SetLastError = true)]
		private static extern int GetVersionEx(ref OSVERSIONINFO lpVersionInformation);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int lstrcpyA([MarshalAs(UnmanagedType.VBByRefStr)] ref string RetVal, int Ptr);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int lstrlenA(int Ptr);

		[DllImport("winspool.drv", CharSet = CharSet.Ansi, EntryPoint = "EnumPrintersA", ExactSpelling = true, SetLastError = true)]
		private static extern int EnumPrinters(int Flags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Name, int Level, ref int pPrinterEnum, int cdBuf, ref int pcbNeeded, ref int pcReturned);

		private static bool BkDXFPrinter_IsWinNT()
		{
			if ($STATIC$BkDXFPrinter_IsWinNT$002$stypOS.dwPlatformId == 0)
		{
			$STATIC$BkDXFPrinter_IsWinNT$002$stypOS.dwOSVersionInfoSize = Strings.Len($STATIC$BkDXFPrinter_IsWinNT$002$stypOS);
				GetVersionEx(ref $STATIC$BkDXFPrinter_IsWinNT$002$stypOS);
			$STATIC$BkDXFPrinter_IsWinNT$002$sblnIsWinNT = ($STATIC$BkDXFPrinter_IsWinNT$002$stypOS.dwPlatformId == 2);
			}
			return $STATIC$BkDXFPrinter_IsWinNT$002$sblnIsWinNT;
		}

		private static string BkDXFPrinter_GetPointer(int l)
		{
			string BkDXFPrinter_GetPointer = new string('\0', lstrlenA(l));
			lstrcpyA(ref BkDXFPrinter_GetPointer, l);
			return BkDXFPrinter_GetPointer;
		}

		public static string BkDXFPrinter_DefaultPrinter()
		{
			int dlngFlags = (!BkDXFPrinter_IsWinNT()) ? 2 : 6;
			string Name = null;
			int pPrinterEnum = 0;
			int dlngNeeded = default(int);
			int dlngEntries = default(int);
			EnumPrinters(dlngFlags, ref Name, 5, ref pPrinterEnum, 0, ref dlngNeeded, ref dlngEntries);
			checked
			{
				PRINTER_INFO_5[] dtypPrinterInfo = new PRINTER_INFO_5[unchecked(dlngNeeded / 20) + 1];
				int dlngBuffer = dlngNeeded;
				string dstrName = default(string);
				return dstrName;
			}
		}
	}
}
