using DXFLib.Acad;
using DXFLib.Basic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DXFLib.DXF
{
	public class UtilTime
	{
		private struct SYSTEMTIME
		{
			public short wYear;

			public short wMonth;

			public short wDayOfWeek;

			public short wDay;

			public short wHour;

			public short wMinute;

			public short wSecond;

			public short wMilliseconds;
		}

		private struct JULDATE_LONG
		{
			public int jdTime;

			public int jdDays;
		}

		private struct JULDATE_CURRENCY
		{
			public decimal jdCompl;
		}

		private const string cstrClassName = "UtilTime";

		private const int clngHoursPerDay = 24;

		private const int clngMinutesPerHour = 60;

		private const int clngMinutesPerDay = 1440;

		private const int clngSecondsPerMinutes = 60;

		private const int clngSecondsPerHour = 3600;

		private const int clngSecondsPerDay = 86400;

		private const int clngMilliSecsPerSecond = 1000;

		private const int clngMilliSecsPerMinute = 60000;

		private const int clngMilliSecsPerHour = 3600000;

		private const int clngMilliSecsPerDay = 86400000;

		private const int clngMinJulTimeHour = 0;

		private const int clngMaxJulTimeHour = 575;

		private const int clngMinMinutesPerHour = 0;

		private const int clngMaxMinutesPerHour = 59;

		private const int clngMinSecondsPerMinutes = 0;

		private const int clngMaxSecondsPerMinutes = 59;

		private const int clngMinMilliSecsPerSecond = 0;

		private const int clngMaxMilliSecsPerSecond = 999;

		private const int clngMinMilliSecsPerDay = 0;

		private const int clngMaxMilliSecsPerDay = 86399999;

		[DateTimeConstant(499230432000000000L)]
		private static readonly DateTime cdatMinVbDate = new DateTime(499230432000000000L);

		[DateTimeConstant(693937151990000000L)]
		private static readonly DateTime cdatMaxVbDate = new DateTime(693937151990000000L);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern void GetSystemTime(ref SYSTEMTIME lpSystemTime);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern void GetLocalTime(ref SYSTEMTIME lpSystemTime);

		public bool IsJulDate(decimal vcurJulDate)
		{
			JULDATE_LONG dtypJulDateLng = InternGetJulSplit(vcurJulDate);
			bool dblnOk = true;
			int jdTime = dtypJulDateLng.jdTime;
			if (jdTime < 0)
			{
				dblnOk = false;
			}
			else if (jdTime > 86399999)
			{
				dblnOk = false;
			}
			else if (dtypJulDateLng.jdDays < 1)
			{
				dblnOk = false;
			}
			return dblnOk;
		}

		public Enums.TiJulDateType JulDateType(decimal vcurJulDate)
		{
			JULDATE_LONG dtypJulDateLng = InternGetJulSplit(vcurJulDate);
			return InternJulDateType(dtypJulDateLng.jdDays, dtypJulDateLng.jdTime);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal NowJulTime(bool nvblnGlobal = false)
		{
			try
			{
				SYSTEMTIME dstypSysTime = default(SYSTEMTIME);
				if (nvblnGlobal)
				{
					GetSystemTime(ref dstypSysTime);
				}
				else
				{
					GetLocalTime(ref dstypSysTime);
				}
				return MakeJulTime(dstypSysTime.wHour, dstypSysTime.wMinute, dstypSysTime.wSecond, dstypSysTime.wMilliseconds);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Ermitteln der aktuellen Zeit.\n" + dstrErrMsg);
				decimal NowJulTime = -1m;
				ProjectData.ClearProjectError();
				return NowJulTime;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal NowJulDate(bool nvblnGlobal = false)
		{
			try
			{
				SYSTEMTIME dstypSysTime = default(SYSTEMTIME);
				if (nvblnGlobal)
				{
					GetSystemTime(ref dstypSysTime);
				}
				else
				{
					GetLocalTime(ref dstypSysTime);
				}
				return MakeJulDate(dstypSysTime.wDay, dstypSysTime.wMonth, dstypSysTime.wYear, dstypSysTime.wHour, dstypSysTime.wMinute, dstypSysTime.wSecond, dstypSysTime.wMilliseconds);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Ermitteln des aktuellen Datums.\n" + dstrErrMsg);
				decimal NowJulDate = -1m;
				ProjectData.ClearProjectError();
				return NowJulDate;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public short JulDateDays(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				short JulDateDays = default(short);
				return JulDateDays;
			}
			return InternJulDateDays(vcurJulDate);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public short JulDateHours(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				short JulDateHours = default(short);
				return JulDateHours;
			}
			return InternJulDateHours(vcurJulDate);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public short JulDateMinutes(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				short JulDateMinutes = default(short);
				return JulDateMinutes;
			}
			return InternJulDateMinutes(vcurJulDate);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public short JulDateSeconds(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				short JulDateSeconds = default(short);
				return JulDateSeconds;
			}
			return InternJulDateSeconds(vcurJulDate);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public short JulDateMilliSecs(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				short JulDateMilliSecs = default(short);
				return JulDateMilliSecs;
			}
			return InternJulDateMilliSecs(vcurJulDate);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object NowAcadDate(bool nvblnGlobal = false)
		{
			try
			{
				return RuntimeHelpers.GetObjectValue(JulDateToAcadDate(NowJulDate(nvblnGlobal)));
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Ermitteln des aktuellen Datums.\n" + dstrErrMsg);
				object NowAcadDate = -1m;
				ProjectData.ClearProjectError();
				return NowAcadDate;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object NowAcadCDate(bool nvblnGlobal = false)
		{
			try
			{
				return RuntimeHelpers.GetObjectValue(InternCDateForAcad(JulDateToDate(NowJulDate(nvblnGlobal))));
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Ermitteln des aktuellen Datums.\n" + dstrErrMsg);
				object NowAcadCDate = -1m;
				ProjectData.ClearProjectError();
				return NowAcadCDate;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal AcadDateToJulDate(object vdecAcadDate)
		{
			decimal AcadDateToJulDate = default(decimal);
			try
			{
				vdecAcadDate = Conversions.ToDecimal(vdecAcadDate);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex2 = ex3;
				string dstrErrMsg2 = ExceptionHelper.GetExceptionMessage(ex2);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Konvertieren des Datums.\n" + dstrErrMsg2);
				ProjectData.ClearProjectError();
				return AcadDateToJulDate;
			}
			int dlngDays = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(vdecAcadDate)));
			int dlngTime = Conversions.ToInteger(Operators.MultiplyObject(new decimal(100000000L), Operators.SubtractObject(vdecAcadDate, new decimal(dlngDays))));
			try
			{
				AcadDateToJulDate = InternGetCurrencyDate(dlngDays, dlngTime);
				return AcadDateToJulDate;
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception ex = ex4;
				string dstrErrMsg2 = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Konvertieren des Datums.\n" + dstrErrMsg2);
				ProjectData.ClearProjectError();
				return AcadDateToJulDate;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object JulDateToAcadDate(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				object JulDateToAcadDate = default(object);
				return JulDateToAcadDate;
			}
			JULDATE_LONG dtypJulDateLng = InternGetJulSplit(vcurJulDate);
			return decimal.Add(new decimal(dtypJulDateLng.jdDays), decimal.Divide(new decimal(dtypJulDateLng.jdTime), new decimal(100000000L)));
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal DateToJulDate(DateTime vdatDate)
		{
			decimal DateToJulDate = default(decimal);
			if ((DateTime.Compare(vdatDate, new DateTime(499230432000000000L)) < 0) | (DateTime.Compare(vdatDate, new DateTime(693937151990000000L)) > 0))
			{
				Information.Err().Raise(50000, "UtilTime", "Datum außerhalb des Gültigkeitsbereiches.");
				return DateToJulDate;
			}
			try
			{
				DateToJulDate = checked(MakeJulDate((short)DateAndTime.Day(vdatDate), (short)DateAndTime.Month(vdatDate), (short)DateAndTime.Year(vdatDate), (short)DateAndTime.Hour(vdatDate), (short)DateAndTime.Minute(vdatDate), (short)DateAndTime.Second(vdatDate), 0));
				return DateToJulDate;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Konvertieren des Datums.\n" + dstrErrMsg);
				ProjectData.ClearProjectError();
				return DateToJulDate;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public DateTime JulDateToDate(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
			}
			else
			{
				JULDATE_LONG dtypJulDateLng = InternGetJulSplit(vcurJulDate);
				int dlngTime = dtypJulDateLng.jdTime;
				DateTime ddatTemp = DateTime.FromOADate(InternGetGregDate(dtypJulDateLng.jdDays).ToOADate() + DateAndTime.TimeSerial(InternTimeToHours(dlngTime), InternTimeToMinutes(dlngTime), InternTimeToSeconds(dlngTime)).ToOADate());
				DateTime t = ddatTemp;
				if (DateTime.Compare(t, new DateTime(499230432000000000L)) < 0)
				{
					Information.Err().Raise(50000, "UtilTime", "Das Ergebnis liefert ein Datum, das vor dem Gültigkeitsbereich liegt.");
				}
				else
				{
					if (DateTime.Compare(t, new DateTime(693937151990000000L)) <= 0)
					{
						return ddatTemp;
					}
					Information.Err().Raise(50000, "UtilTime", "Das Ergebnis liefert ein Datum, das nach dem Gültigkeitsbereich liegt.");
				}
			}
			DateTime JulDateToDate = default(DateTime);
			return JulDateToDate;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal MakeJulDate(short vintDay, short vintMonth, short vintYear, short nvintHour = 0, short nvintMinute = 0, short nvintSecond = 0, short nvintMilliSec = 0)
		{
			string dstrRefString = Support.Format(vintDay, "00\\.") + Support.Format(vintMonth, "00\\.") + Support.Format(vintYear, "0000\\ ") + Support.Format(nvintHour, "00\\:") + Support.Format(nvintMinute, "00\\:") + Support.Format(nvintSecond, "00");
			string dstrInpString = Conversions.ToString(DateTime.FromOADate(DateAndTime.DateSerial(vintYear, vintMonth, vintDay).ToOADate() + DateAndTime.TimeSerial(nvintHour, nvintMinute, nvintSecond).ToOADate()));
			if (Operators.CompareString(Support.Format(dstrInpString, "dd\\.mm\\.yyyy\\ hh\\:nn\\:ss"), dstrRefString, TextCompare: false) != 0)
			{
				Information.Err().Raise(50000, "UtilTime", "Der Datumswert ist ungültig.");
			}
			else
			{
				if (!(nvintMilliSec < 0 || nvintMilliSec > 999))
				{
					JULDATE_LONG dtypJulDateLng = default(JULDATE_LONG);
					dtypJulDateLng.jdDays = InternGetJulDays(vintDay, vintMonth, vintYear);
					dtypJulDateLng.jdTime = InternCalcJulTime(nvintHour, nvintMinute, nvintSecond, nvintMilliSec);
					JULDATE_CURRENCY dtypJulDateCur = InternJulDatLngToJulDateCur(dtypJulDateLng);
					return dtypJulDateCur.jdCompl;
				}
				Information.Err().Raise(50000, "UtilTime", "Millisekunden außerhalb des Gültigkeitsbereiches.");
			}
			decimal MakeJulDate = default(decimal);
			return MakeJulDate;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal MakeJulTime(short nvintHour = 0, short nvintMinute = 0, short nvintSecond = 0, short nvintMilliSec = 0)
		{
			bool flag = true;
			if (flag == nvintHour < 0 || flag == nvintHour > 575)
			{
				Information.Err().Raise(50000, "UtilTime", "Der Stundenwert überschreitet den Gültigkeitsbereich.");
			}
			else if (flag == nvintMinute < 0 || flag == nvintMinute > 59)
			{
				Information.Err().Raise(50000, "UtilTime", "Der Minutenwert überschreitet den Gültigkeitsbereich.");
			}
			else if (flag == nvintSecond < 0 || flag == nvintSecond > 59)
			{
				Information.Err().Raise(50000, "UtilTime", "Der Sekundenwert überschreitet den Gültigkeitsbereich.");
			}
			else
			{
				if (flag != nvintMilliSec < 0 && flag != nvintMilliSec > 999)
				{
					JULDATE_LONG dtypJulDateLng = default(JULDATE_LONG);
					dtypJulDateLng.jdDays = 0;
					dtypJulDateLng.jdTime = InternCalcJulTime(nvintHour, nvintMinute, nvintSecond, nvintMilliSec);
					JULDATE_CURRENCY dtypJulDateCur = InternJulDatLngToJulDateCur(dtypJulDateLng);
					return dtypJulDateCur.jdCompl;
				}
				Information.Err().Raise(50000, "UtilTime", "Der Millisekundenwert überschreitet den Gültigkeitsbereich.");
			}
			decimal MakeJulTime = default(decimal);
			return MakeJulTime;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object JulDateGetIntervall(Enums.TiJulDateIntervall vnumIntervall, decimal vcurJulDate1, decimal vcurJulDate2)
		{
			if (!IsJulDate(vcurJulDate1))
			{
				Information.Err().Raise(50000, "UtilTime", "Das erste Datum ist ungültig.");
			}
			else
			{
				if (IsJulDate(vcurJulDate2))
				{
					JULDATE_LONG dtypJulDateLng1 = InternGetJulSplit(vcurJulDate1);
					JULDATE_LONG dtypJulDateLng2 = InternGetJulSplit(vcurJulDate2);
					int dlngTime1 = dtypJulDateLng1.jdTime;
					int dlngTime2 = dtypJulDateLng2.jdTime;
					object dvarVarDat1 = default(object);
					object dvarVarDat2 = default(object);
					switch (vnumIntervall)
					{
						case Enums.TiJulDateIntervall.tiDays:
							dvarVarDat1 = new decimal(dtypJulDateLng1.jdDays);
							dvarVarDat2 = new decimal(dtypJulDateLng2.jdDays);
							break;
						case Enums.TiJulDateIntervall.tiHours:
							dvarVarDat1 = decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng1.jdDays), new decimal(24L)), new decimal(InternTimeToHours(dlngTime1)));
							dvarVarDat2 = decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng2.jdDays), new decimal(24L)), new decimal(InternTimeToHours(dlngTime2)));
							break;
						case Enums.TiJulDateIntervall.tiMinutes:
							dvarVarDat1 = decimal.Add(decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng1.jdDays), new decimal(1440L)), decimal.Multiply(new decimal(InternTimeToHours(dlngTime1)), new decimal(60L))), new decimal(InternTimeToMinutes(dlngTime1)));
							dvarVarDat2 = decimal.Add(decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng2.jdDays), new decimal(1440L)), decimal.Multiply(new decimal(InternTimeToHours(dlngTime2)), new decimal(60L))), new decimal(InternTimeToMinutes(dlngTime2)));
							break;
						case Enums.TiJulDateIntervall.tiSeconds:
							dvarVarDat1 = decimal.Add(decimal.Add(decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng1.jdDays), new decimal(86400L)), decimal.Multiply(new decimal(InternTimeToHours(dlngTime1)), new decimal(3600L))), decimal.Multiply(new decimal(InternTimeToMinutes(dlngTime1)), new decimal(60L))), new decimal(InternTimeToSeconds(dlngTime1)));
							dvarVarDat2 = decimal.Add(decimal.Add(decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng2.jdDays), new decimal(86400L)), decimal.Multiply(new decimal(InternTimeToHours(dlngTime2)), new decimal(3600L))), decimal.Multiply(new decimal(InternTimeToMinutes(dlngTime2)), new decimal(60L))), new decimal(InternTimeToSeconds(dlngTime2)));
							break;
						case Enums.TiJulDateIntervall.tiMilliSecs:
							dvarVarDat1 = decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng1.jdDays), new decimal(86400000L)), decimal.Multiply(new decimal(InternTimeToHours(dlngTime1)), new decimal(3600000L))), decimal.Multiply(new decimal(InternTimeToMinutes(dlngTime1)), new decimal(60000L))), decimal.Multiply(new decimal(InternTimeToSeconds(dlngTime1)), new decimal(1000L))), new decimal(InternTimeToMilliSecs(dlngTime1)));
							dvarVarDat2 = decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Multiply(new decimal(dtypJulDateLng2.jdDays), new decimal(86400000L)), decimal.Multiply(new decimal(InternTimeToHours(dlngTime2)), new decimal(3600000L))), decimal.Multiply(new decimal(InternTimeToMinutes(dlngTime2)), new decimal(60000L))), decimal.Multiply(new decimal(InternTimeToSeconds(dlngTime2)), new decimal(1000L))), new decimal(InternTimeToMilliSecs(dlngTime2)));
							break;
					}
					return Conversions.ToDecimal(Operators.SubtractObject(dvarVarDat2, dvarVarDat1));
				}
				Information.Err().Raise(50000, "UtilTime", "Das zweite Datum ist ungültig.");
			}
			object JulDateGetIntervall = default(object);
			return JulDateGetIntervall;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal JulDateCalc(Enums.TiJulDateCalcModus vnumCalcModus, decimal vcurJulDate1, decimal vcurJulDate2)
		{
			JULDATE_LONG dtypJulDateLng1 = InternGetJulSplit(vcurJulDate1);
			JULDATE_LONG dtypJulDateLng2 = InternGetJulSplit(vcurJulDate2);
			int dlngDays2 = dtypJulDateLng1.jdDays;
			int dlngDays3 = dtypJulDateLng2.jdDays;
			int dlngTime2 = dtypJulDateLng1.jdTime;
			int dlngTime3 = dtypJulDateLng2.jdTime;
			Enums.TiJulDateType tiJulDateType = InternJulDateType(dlngDays2, dlngTime2);
			int dlngDays = default(int);
			int dlngTime = default(int);
			checked
			{
				if (tiJulDateType != 0)
				{
					if (tiJulDateType == Enums.TiJulDateType.tiJulTimeOnly)
					{
						InternCheckTime(ref dlngDays2, ref dlngTime2);
					}
					Enums.TiJulDateType tiJulDateType2 = InternJulDateType(dlngDays3, dlngTime3);
					if (tiJulDateType2 != 0)
					{
						if (tiJulDateType2 == Enums.TiJulDateType.tiJulTimeOnly)
						{
							InternCheckTime(ref dlngDays3, ref dlngTime3);
						}
						if (vnumCalcModus != Enums.TiJulDateCalcModus.tiAddDates)
						{
							if (vnumCalcModus == Enums.TiJulDateCalcModus.tiSubDates)
							{
								dlngDays = dlngDays2 - dlngDays3;
								dlngTime = dlngTime2 - dlngTime3;
								InternCheckMinTime(ref dlngDays, ref dlngTime);
								Enums.TiJulDateType tiJulDateType3 = InternJulDateType(dlngDays, dlngTime);
								if (tiJulDateType3 != Enums.TiJulDateType.tiJulDateTime)
								{
									if (tiJulDateType3 != Enums.TiJulDateType.tiJulTimeOnly || dlngDays >= 0)
									{
										goto IL_018d;
									}
									Information.Err().Raise(50000, "UtilTime", "Subtraktion unterschreitet den Wertebereich.");
								}
								else
								{
									if (dlngDays >= 1)
									{
										goto IL_018d;
									}
									Information.Err().Raise(50000, "UtilTime", "Subtraktion unterschreitet den Wertebereich.");
								}
								goto IL_01d6;
							}
						}
						else
						{
							dlngDays = dlngDays2 + dlngDays3;
							dlngTime = dlngTime2 + dlngTime3;
							InternCheckMaxTime(ref dlngDays, ref dlngTime);
						}
						goto IL_018d;
					}
					Information.Err().Raise(50000, "UtilTime", "Das zweite Datum ist ungültig.");
				}
				else
				{
					Information.Err().Raise(50000, "UtilTime", "Das erste Datum ist ungültig.");
				}
				goto IL_01d6;
			}
		IL_01d6:
			decimal JulDateCalc = default(decimal);
			return JulDateCalc;
		IL_018d:
			try
			{
				JulDateCalc = InternGetCurrencyDate(dlngDays, dlngTime);
				return JulDateCalc;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "UtilTime", "Fehler beim Addieren/Subtrahieren der Datumsangaben.\n" + dstrErrMsg);
				ProjectData.ClearProjectError();
				JulDateCalc = default(decimal);
				return JulDateCalc;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public string JulDateToTimeString(decimal vcurJulDate)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				string JulDateToTimeString = default(string);
				return JulDateToTimeString;
			}
			return Support.Format(InternJulDateHours(vcurJulDate), "00\\:") + Support.Format(InternJulDateMinutes(vcurJulDate), "00\\:") + Support.Format(InternJulDateSeconds(vcurJulDate), "00\\.") + Support.Format(InternJulDateMilliSecs(vcurJulDate), "000");
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public decimal JulDateAddIntervall(Enums.TiJulDateIntervall vnumIntervall, decimal vcurJulDate, int vlngValue)
		{
			if (!IsJulDate(vcurJulDate))
			{
				Information.Err().Raise(50000, "UtilTime", "Das Datum ist ungültig.");
				goto IL_025a;
			}
			int dlngDays2 = default(int);
			int dlngTime2 = default(int);
			switch (vnumIntervall)
			{
				case Enums.TiJulDateIntervall.tiDays:
					dlngDays2 = Math.Abs(vlngValue);
					dlngTime2 = 0;
					break;
				case Enums.TiJulDateIntervall.tiHours:
					dlngDays2 = Math.Abs(vlngValue) / 24;
					dlngTime2 = Convert.ToInt32(decimal.Subtract(decimal.Multiply(new decimal(Math.Abs(vlngValue)), new decimal(3600000L)), decimal.Multiply(new decimal(dlngDays2), new decimal(86400000L))));
					break;
				case Enums.TiJulDateIntervall.tiMinutes:
					dlngDays2 = Math.Abs(vlngValue) / 1440;
					dlngTime2 = Convert.ToInt32(decimal.Subtract(decimal.Multiply(new decimal(Math.Abs(vlngValue)), new decimal(60000L)), decimal.Multiply(new decimal(dlngDays2), new decimal(86400000L))));
					break;
				case Enums.TiJulDateIntervall.tiSeconds:
					dlngDays2 = Math.Abs(vlngValue) / 86400;
					dlngTime2 = Convert.ToInt32(decimal.Subtract(decimal.Multiply(new decimal(Math.Abs(vlngValue)), new decimal(1000L)), decimal.Multiply(new decimal(dlngDays2), new decimal(86400000L))));
					break;
				case Enums.TiJulDateIntervall.tiMilliSecs:
					dlngDays2 = Math.Abs(vlngValue) / 86400000;
					dlngTime2 = Convert.ToInt32(decimal.Subtract(new decimal(Math.Abs(vlngValue)), decimal.Multiply(new decimal(dlngDays2), new decimal(86400000L))));
					break;
			}
			JULDATE_LONG dtypJulDateLng = InternGetJulSplit(vcurJulDate);
			decimal JulDateAddIntervall = default(decimal);
			checked
			{
				if (vlngValue >= 0)
				{
					dlngDays2 = dtypJulDateLng.jdDays + dlngDays2;
					dlngTime2 = dtypJulDateLng.jdTime + dlngTime2;
					InternCheckMaxTime(ref dlngDays2, ref dlngTime2);
				}
				else
				{
					dlngDays2 = dtypJulDateLng.jdDays - dlngDays2;
					if (dlngDays2 < 1)
					{
						Information.Err().Raise(50000, "UtilTime", "Subtraktion unterschreitet den Wertebereich.");
						goto IL_025a;
					}
					dlngTime2 = dtypJulDateLng.jdTime - dlngTime2;
					InternCheckMinTime(ref dlngDays2, ref dlngTime2);
				}
				try
				{
					JulDateAddIntervall = InternGetCurrencyDate(dlngDays2, dlngTime2);
					return JulDateAddIntervall;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
					Information.Err().Raise(50000, "UtilTime", "Fehler beim Addieren/Subtrahieren des Intervalls.\n" + dstrErrMsg);
					ProjectData.ClearProjectError();
					return JulDateAddIntervall;
				}
			}
		IL_025a:
			JulDateAddIntervall = default;
			return JulDateAddIntervall;
		}

		private JULDATE_LONG InternGetJulSplit(decimal vcurJulDate)
		{
			JULDATE_CURRENCY dtypJulDateCur = default(JULDATE_CURRENCY);
			dtypJulDateCur.jdCompl = vcurJulDate;
			return InternJulDatCurToJulDateLng(dtypJulDateCur);
		}

		private short InternJulDateDays(decimal vcurJulDate)
		{
			return checked((short)InternGetJulSplit(vcurJulDate).jdDays);
		}

		private short InternJulDateHours(decimal vcurJulDate)
		{
			return InternTimeToHours(InternGetJulSplit(vcurJulDate).jdTime);
		}

		private short InternTimeToHours(int vlngTime)
		{
			checked
			{
				return (short)unchecked(vlngTime / 3600000);
			}
		}

		private short InternJulDateMinutes(decimal vcurJulDate)
		{
			return InternTimeToMinutes(InternGetJulSplit(vcurJulDate).jdTime);
		}

		private short InternTimeToMinutes(int vlngTime)
		{
			vlngTime /= 60000;
			checked
			{
				return (short)(vlngTime - unchecked(vlngTime / 60) * 60);
			}
		}

		private short InternJulDateSeconds(decimal vcurJulDate)
		{
			return InternTimeToSeconds(InternGetJulSplit(vcurJulDate).jdTime);
		}

		private short InternTimeToSeconds(int vlngTime)
		{
			vlngTime /= 1000;
			checked
			{
				return (short)(vlngTime - unchecked(vlngTime / 60) * 60);
			}
		}

		private short InternJulDateMilliSecs(decimal vcurJulDate)
		{
			return InternTimeToMilliSecs(InternGetJulSplit(vcurJulDate).jdTime);
		}

		private short InternTimeToMilliSecs(int vlngTime)
		{
			checked
			{
				return (short)(vlngTime - unchecked(vlngTime / 1000) * 1000);
			}
		}

		private int InternCalcJulTime(short vintHour, short vintMinute, short vintSecond, short vintMilliSec)
		{
			return checked(3600000 * vintHour + 60000 * vintMinute + 1000 * vintSecond + vintMilliSec);
		}

		private void InternCheckTime(ref int rlngDays, ref int rlngTime)
		{
			checked
			{
				if (rlngTime > 86399999)
				{
					int dlngDays = (int)((double)rlngTime / 86400000.0);
					rlngTime -= dlngDays * 86400000;
					rlngDays += dlngDays;
				}
			}
		}

		private void InternCheckMaxTime(ref int rlngDays, ref int rlngTime)
		{
			checked
			{
				if (rlngTime > 86399999)
				{
					rlngDays++;
					rlngTime -= 86400000;
				}
			}
		}

		private void InternCheckMinTime(ref int rlngDays, ref int rlngTime)
		{
			checked
			{
				if (rlngTime < 0)
				{
					rlngDays--;
					rlngTime = 86399999 + rlngTime;
				}
			}
		}

		private Enums.TiJulDateType InternJulDateType(int vlngDays, int vlngTime)
		{
			if (vlngDays < 0)
			{
				return Enums.TiJulDateType.tiNotValid;
			}
			if (vlngDays == 0)
			{
				if (vlngTime < 0)
				{
					return Enums.TiJulDateType.tiNotValid;
				}
				return Enums.TiJulDateType.tiJulTimeOnly;
			}
			if (vlngTime < 0 || vlngTime > 86399999)
			{
				return Enums.TiJulDateType.tiNotValid;
			}
			return Enums.TiJulDateType.tiJulDateTime;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private decimal InternGetCurrencyDate(int vlngDays, int vlngTime)
		{
			if (vlngTime < 0)
			{
				Information.Err().Raise(50000, "UtilTime", "Zeit liegt außerhalb des Wertebereichs (<00:00:00:000).");
			}
			else if (vlngTime > 86399999)
			{
				Information.Err().Raise(50000, "UtilTime", "Zeit liegt außerhalb des Wertebereichs (>23:59:59:999).");
			}
			else
			{
				JULDATE_LONG dtypJulDateLng = default(JULDATE_LONG);
				dtypJulDateLng.jdTime = vlngTime;
				if (vlngDays >= 0)
				{
					dtypJulDateLng.jdDays = vlngDays;
					JULDATE_CURRENCY dtypJulDateCur = InternJulDatLngToJulDateCur(dtypJulDateLng);
					return dtypJulDateCur.jdCompl;
				}
				Information.Err().Raise(50000, "UtilTime", "Tagesdatum außerhalb des Wertebereichs.");
			}
			decimal InternGetCurrencyDate = default(decimal);
			return InternGetCurrencyDate;
		}

		private int InternGetJulDays(short vintDay, short vintMonth, short vintYear)
		{
			checked
			{
				int dlngYear = (vintYear >= 0) ? vintYear : (vintYear + 1);
				int dlngMonth;
				if (vintMonth > 2)
				{
					dlngMonth = vintMonth + 1;
				}
				else
				{
					dlngYear--;
					dlngMonth = vintMonth + 13;
				}
				object dvarJulDate = decimal.Add(decimal.Add(decimal.Add(Conversion.Int(decimal.Divide(decimal.Multiply(new decimal(1461L), new decimal(dlngYear)), new decimal(4L))), Conversion.Int(decimal.Divide(decimal.Multiply(new decimal(153L), new decimal(dlngMonth)), new decimal(5L)))), new decimal(vintDay)), new decimal(1720995L));
				object dvarD = decimal.Add(new decimal(vintDay), decimal.Multiply(new decimal(31L), decimal.Add(new decimal(dlngMonth), decimal.Multiply(new decimal(12L), new decimal(dlngYear)))));
				if (Operators.ConditionalCompareObjectGreaterEqual(dvarD, new decimal(588829L), TextCompare: false))
				{
					object dvarA = Conversion.Int(decimal.Divide(new decimal(dlngYear), new decimal(100L)));
					dvarJulDate = Operators.AddObject(dvarJulDate, Conversions.ToDecimal(Operators.AddObject(Operators.SubtractObject(2, dvarA), Conversions.ToDecimal(Conversion.Int(Operators.DivideObject(dvarA, 4))))));
				}
				return Conversions.ToInteger(dvarJulDate);
			}
		}

		private DateTime InternGetGregDate(int lngJulDat)
		{
			object dvarJulDate = decimal.Add(new decimal(lngJulDat), 1m);
			object dvarA;
			if (Operators.ConditionalCompareObjectLess(dvarJulDate, new decimal(2299161L), TextCompare: false))
			{
				dvarA = Conversions.ToDecimal(dvarJulDate);
			}
			else
			{
				object varALPHA = new decimal(Conversion.Int(Convert.ToDouble(Conversions.ToDecimal(Operators.SubtractObject(dvarJulDate, 1867216.25))) / 36524.25));
				dvarA = Conversions.ToDecimal(Operators.SubtractObject(Operators.AddObject(Operators.AddObject(dvarJulDate, 1), varALPHA), Conversions.ToDecimal(Conversion.Int(Operators.DivideObject(varALPHA, 4)))));
			}
			object varB = Conversions.ToDecimal(Operators.AddObject(dvarA, 1524));
			object varC = new decimal(Conversion.Int(Convert.ToDouble(Conversions.ToDecimal(Operators.SubtractObject(varB, 122.1))) / 365.25));
			object dvarD = Conversion.Int(decimal.Divide(Conversions.ToDecimal(Operators.MultiplyObject(1461, varC)), new decimal(4L)));
			object varE = new decimal(Conversion.Int(Convert.ToDouble(Conversions.ToDecimal(Operators.SubtractObject(varB, dvarD))) / 30.6001));
			object varDay = Conversion.Int(decimal.Subtract(decimal.Subtract(Conversions.ToDecimal(Operators.SubtractObject(varB, dvarD)), Conversions.ToDecimal(Conversion.Int(Operators.MultiplyObject(30.6001, varE)))), 1m));
			object varMonth = (!Operators.ConditionalCompareObjectLess(varE, 13.5m, TextCompare: false)) ? ((object)Conversions.ToDecimal(Operators.SubtractObject(varE, 13))) : ((object)Conversions.ToDecimal(Operators.SubtractObject(varE, 1)));
			object varYear = (!Operators.ConditionalCompareObjectGreater(varMonth, 2.5m, TextCompare: false)) ? ((object)Conversions.ToDecimal(Operators.SubtractObject(varC, 4715))) : ((object)Conversions.ToDecimal(Operators.SubtractObject(varC, 4716)));
			return checked(DateAndTime.DateSerial((int)Conversion.Int(Conversions.ToDouble(varYear)), (int)Conversion.Int(Conversions.ToDouble(varMonth)), (int)Conversion.Int(Conversions.ToDouble(varDay))));
		}

		private object InternCDateForAcad(DateTime vdatDate)
		{
			return Conversions.ToDecimal(Strings.Replace(Support.Format(vdatDate, "YYYYMMDD.HHMMSS"), ".", ","));
		}

		private JULDATE_CURRENCY InternJulDatLngToJulDateCur(JULDATE_LONG vtypJulDateLng)
		{
			JULDATE_CURRENCY dtypJulDateCur = default(JULDATE_CURRENCY);
			dtypJulDateCur.jdCompl = Conversions.ToDecimal(vtypJulDateLng.jdDays + "," + vtypJulDateLng.jdTime);
			return dtypJulDateCur;
		}

		private JULDATE_LONG InternJulDatCurToJulDateLng(JULDATE_CURRENCY vtypJulDateCur)
		{
			string[] dastrValues = vtypJulDateCur.jdCompl.ToString().Split(',');
			checked
			{
				JULDATE_LONG dtypJulDateLng = default(JULDATE_LONG);
				dtypJulDateLng.jdDays = (int)Conversions.ToLong(dastrValues[0]);
				dtypJulDateLng.jdTime = (int)Conversions.ToLong(dastrValues[1]);
				return dtypJulDateLng;
			}
		}
	}
}
