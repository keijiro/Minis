using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Minis {

//
// MIDI device state struct
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MidiDeviceState : IInputStateTypeInfo
{
    public FourCC format => new FourCC('M', 'I', 'D', 'J');

    [InputControl(name = "note000", displayName = "Note C-1", shortDisplayName = "C-1", layout = "MidiNote", offset = 0)]  public byte note000;
    [InputControl(name = "note001", displayName = "Note C#-1", shortDisplayName = "C#-1", layout = "MidiNote", offset = 1)]  public byte note001;
    [InputControl(name = "note002", displayName = "Note D-1", shortDisplayName = "D-1", layout = "MidiNote", offset = 2)]  public byte note002;
    [InputControl(name = "note003", displayName = "Note D#-1", shortDisplayName = "D#-1", layout = "MidiNote", offset = 3)]  public byte note003;
    [InputControl(name = "note004", displayName = "Note E-1", shortDisplayName = "E-1", layout = "MidiNote", offset = 4)]  public byte note004;
    [InputControl(name = "note005", displayName = "Note F-1", shortDisplayName = "F-1", layout = "MidiNote", offset = 5)]  public byte note005;
    [InputControl(name = "note006", displayName = "Note F#-1", shortDisplayName = "F#-1", layout = "MidiNote", offset = 6)]  public byte note006;
    [InputControl(name = "note007", displayName = "Note G-1", shortDisplayName = "G-1", layout = "MidiNote", offset = 7)]  public byte note007;
    [InputControl(name = "note008", displayName = "Note G#-1", shortDisplayName = "G#-1", layout = "MidiNote", offset = 8)]  public byte note008;
    [InputControl(name = "note009", displayName = "Note A-1", shortDisplayName = "A-1", layout = "MidiNote", offset = 9)]  public byte note009;
    [InputControl(name = "note010", displayName = "Note A#-1", shortDisplayName = "A#-1", layout = "MidiNote", offset = 10)] public byte note010;
    [InputControl(name = "note011", displayName = "Note B-1", shortDisplayName = "B-1", layout = "MidiNote", offset = 11)] public byte note011;
    [InputControl(name = "note012", displayName = "Note C0",  shortDisplayName = "C0",  layout = "MidiNote", offset = 12)] public byte note012;
    [InputControl(name = "note013", displayName = "Note C#0", shortDisplayName = "C#0", layout = "MidiNote", offset = 13)] public byte note013;
    [InputControl(name = "note014", displayName = "Note D0",  shortDisplayName = "D0",  layout = "MidiNote", offset = 14)] public byte note014;
    [InputControl(name = "note015", displayName = "Note D#0", shortDisplayName = "D#0", layout = "MidiNote", offset = 15)] public byte note015;
    [InputControl(name = "note016", displayName = "Note E0",  shortDisplayName = "E0",  layout = "MidiNote", offset = 16)] public byte note016;
    [InputControl(name = "note017", displayName = "Note F0",  shortDisplayName = "F0",  layout = "MidiNote", offset = 17)] public byte note017;
    [InputControl(name = "note018", displayName = "Note F#0", shortDisplayName = "F#0", layout = "MidiNote", offset = 18)] public byte note018;
    [InputControl(name = "note019", displayName = "Note G0",  shortDisplayName = "G0",  layout = "MidiNote", offset = 19)] public byte note019;
    [InputControl(name = "note020", displayName = "Note G#0", shortDisplayName = "G#0", layout = "MidiNote", offset = 20)] public byte note020;
    [InputControl(name = "note021", displayName = "Note A0",  shortDisplayName = "A0",  layout = "MidiNote", offset = 21)] public byte note021;
    [InputControl(name = "note022", displayName = "Note A#0", shortDisplayName = "A#0", layout = "MidiNote", offset = 22)] public byte note022;
    [InputControl(name = "note023", displayName = "Note B0",  shortDisplayName = "B0",  layout = "MidiNote", offset = 23)] public byte note023;
    [InputControl(name = "note024", displayName = "Note C1",  shortDisplayName = "C1",  layout = "MidiNote", offset = 24)] public byte note024;
    [InputControl(name = "note025", displayName = "Note C#1", shortDisplayName = "C#1", layout = "MidiNote", offset = 25)] public byte note025;
    [InputControl(name = "note026", displayName = "Note D1",  shortDisplayName = "D1",  layout = "MidiNote", offset = 26)] public byte note026;
    [InputControl(name = "note027", displayName = "Note D#1", shortDisplayName = "D#1", layout = "MidiNote", offset = 27)] public byte note027;
    [InputControl(name = "note028", displayName = "Note E1",  shortDisplayName = "E1",  layout = "MidiNote", offset = 28)] public byte note028;
    [InputControl(name = "note029", displayName = "Note F1",  shortDisplayName = "F1",  layout = "MidiNote", offset = 29)] public byte note029;
    [InputControl(name = "note030", displayName = "Note F#1", shortDisplayName = "F#1", layout = "MidiNote", offset = 30)] public byte note030;
    [InputControl(name = "note031", displayName = "Note G1",  shortDisplayName = "G1",  layout = "MidiNote", offset = 31)] public byte note031;
    [InputControl(name = "note032", displayName = "Note G#1", shortDisplayName = "G#1", layout = "MidiNote", offset = 32)] public byte note032;
    [InputControl(name = "note033", displayName = "Note A1",  shortDisplayName = "A1",  layout = "MidiNote", offset = 33)] public byte note033;
    [InputControl(name = "note034", displayName = "Note A#1", shortDisplayName = "A#1", layout = "MidiNote", offset = 34)] public byte note034;
    [InputControl(name = "note035", displayName = "Note B1",  shortDisplayName = "B1",  layout = "MidiNote", offset = 35)] public byte note035;
    [InputControl(name = "note036", displayName = "Note C2",  shortDisplayName = "C2",  layout = "MidiNote", offset = 36)] public byte note036;
    [InputControl(name = "note037", displayName = "Note C#2", shortDisplayName = "C#2", layout = "MidiNote", offset = 37)] public byte note037;
    [InputControl(name = "note038", displayName = "Note D2",  shortDisplayName = "D2",  layout = "MidiNote", offset = 38)] public byte note038;
    [InputControl(name = "note039", displayName = "Note D#2", shortDisplayName = "D#2", layout = "MidiNote", offset = 39)] public byte note039;
    [InputControl(name = "note040", displayName = "Note E2",  shortDisplayName = "E2",  layout = "MidiNote", offset = 40)] public byte note040;
    [InputControl(name = "note041", displayName = "Note F2",  shortDisplayName = "F2",  layout = "MidiNote", offset = 41)] public byte note041;
    [InputControl(name = "note042", displayName = "Note F#2", shortDisplayName = "F#2", layout = "MidiNote", offset = 42)] public byte note042;
    [InputControl(name = "note043", displayName = "Note G2",  shortDisplayName = "G2",  layout = "MidiNote", offset = 43)] public byte note043;
    [InputControl(name = "note044", displayName = "Note G#2", shortDisplayName = "G#2", layout = "MidiNote", offset = 44)] public byte note044;
    [InputControl(name = "note045", displayName = "Note A2",  shortDisplayName = "A2",  layout = "MidiNote", offset = 45)] public byte note045;
    [InputControl(name = "note046", displayName = "Note A#2", shortDisplayName = "A#2", layout = "MidiNote", offset = 46)] public byte note046;
    [InputControl(name = "note047", displayName = "Note B2",  shortDisplayName = "B2",  layout = "MidiNote", offset = 47)] public byte note047;
    [InputControl(name = "note048", displayName = "Note C3",  shortDisplayName = "C3",  layout = "MidiNote", offset = 48)] public byte note048;
    [InputControl(name = "note049", displayName = "Note C#3", shortDisplayName = "C#3", layout = "MidiNote", offset = 49)] public byte note049;
    [InputControl(name = "note050", displayName = "Note D3",  shortDisplayName = "D3",  layout = "MidiNote", offset = 50)] public byte note050;
    [InputControl(name = "note051", displayName = "Note D#3", shortDisplayName = "D#3", layout = "MidiNote", offset = 51)] public byte note051;
    [InputControl(name = "note052", displayName = "Note E3",  shortDisplayName = "E3",  layout = "MidiNote", offset = 52)] public byte note052;
    [InputControl(name = "note053", displayName = "Note F3",  shortDisplayName = "F3",  layout = "MidiNote", offset = 53)] public byte note053;
    [InputControl(name = "note054", displayName = "Note F#3", shortDisplayName = "F#3", layout = "MidiNote", offset = 54)] public byte note054;
    [InputControl(name = "note055", displayName = "Note G3",  shortDisplayName = "G3",  layout = "MidiNote", offset = 55)] public byte note055;
    [InputControl(name = "note056", displayName = "Note G#3", shortDisplayName = "G#3", layout = "MidiNote", offset = 56)] public byte note056;
    [InputControl(name = "note057", displayName = "Note A3",  shortDisplayName = "A3",  layout = "MidiNote", offset = 57)] public byte note057;
    [InputControl(name = "note058", displayName = "Note A#3", shortDisplayName = "A#3", layout = "MidiNote", offset = 58)] public byte note058;
    [InputControl(name = "note059", displayName = "Note B3",  shortDisplayName = "B3",  layout = "MidiNote", offset = 59)] public byte note059;
    [InputControl(name = "note060", displayName = "Note C4",  shortDisplayName = "C4",  layout = "MidiNote", offset = 60)] public byte note060;
    [InputControl(name = "note061", displayName = "Note C#4", shortDisplayName = "C#4", layout = "MidiNote", offset = 61)] public byte note061;
    [InputControl(name = "note062", displayName = "Note D4",  shortDisplayName = "D4",  layout = "MidiNote", offset = 62)] public byte note062;
    [InputControl(name = "note063", displayName = "Note D#4", shortDisplayName = "D#4", layout = "MidiNote", offset = 63)] public byte note063;
    [InputControl(name = "note064", displayName = "Note E4",  shortDisplayName = "E4",  layout = "MidiNote", offset = 64)] public byte note064;
    [InputControl(name = "note065", displayName = "Note F4",  shortDisplayName = "F4",  layout = "MidiNote", offset = 65)] public byte note065;
    [InputControl(name = "note066", displayName = "Note F#4", shortDisplayName = "F#4", layout = "MidiNote", offset = 66)] public byte note066;
    [InputControl(name = "note067", displayName = "Note G4",  shortDisplayName = "G4",  layout = "MidiNote", offset = 67)] public byte note067;
    [InputControl(name = "note068", displayName = "Note G#4", shortDisplayName = "G#4", layout = "MidiNote", offset = 68)] public byte note068;
    [InputControl(name = "note069", displayName = "Note A4",  shortDisplayName = "A4",  layout = "MidiNote", offset = 69)] public byte note069;
    [InputControl(name = "note070", displayName = "Note A#4", shortDisplayName = "A#4", layout = "MidiNote", offset = 70)] public byte note070;
    [InputControl(name = "note071", displayName = "Note B4",  shortDisplayName = "B4",  layout = "MidiNote", offset = 71)] public byte note071;
    [InputControl(name = "note072", displayName = "Note C5",  shortDisplayName = "C5",  layout = "MidiNote", offset = 72)] public byte note072;
    [InputControl(name = "note073", displayName = "Note C#5", shortDisplayName = "C#5", layout = "MidiNote", offset = 73)] public byte note073;
    [InputControl(name = "note074", displayName = "Note D5",  shortDisplayName = "D5",  layout = "MidiNote", offset = 74)] public byte note074;
    [InputControl(name = "note075", displayName = "Note D#5", shortDisplayName = "D#5", layout = "MidiNote", offset = 75)] public byte note075;
    [InputControl(name = "note076", displayName = "Note E5",  shortDisplayName = "E5",  layout = "MidiNote", offset = 76)] public byte note076;
    [InputControl(name = "note077", displayName = "Note F5",  shortDisplayName = "F5",  layout = "MidiNote", offset = 77)] public byte note077;
    [InputControl(name = "note078", displayName = "Note F#5", shortDisplayName = "F#5", layout = "MidiNote", offset = 78)] public byte note078;
    [InputControl(name = "note079", displayName = "Note G5",  shortDisplayName = "G5",  layout = "MidiNote", offset = 79)] public byte note079;
    [InputControl(name = "note080", displayName = "Note G#5", shortDisplayName = "G#5", layout = "MidiNote", offset = 80)] public byte note080;
    [InputControl(name = "note081", displayName = "Note A5",  shortDisplayName = "A5",  layout = "MidiNote", offset = 81)] public byte note081;
    [InputControl(name = "note082", displayName = "Note A#5", shortDisplayName = "A#5", layout = "MidiNote", offset = 82)] public byte note082;
    [InputControl(name = "note083", displayName = "Note B5",  shortDisplayName = "B5",  layout = "MidiNote", offset = 83)] public byte note083;
    [InputControl(name = "note084", displayName = "Note C6",  shortDisplayName = "C6",  layout = "MidiNote", offset = 84)] public byte note084;
    [InputControl(name = "note085", displayName = "Note C#6", shortDisplayName = "C#6", layout = "MidiNote", offset = 85)] public byte note085;
    [InputControl(name = "note086", displayName = "Note D6",  shortDisplayName = "D6",  layout = "MidiNote", offset = 86)] public byte note086;
    [InputControl(name = "note087", displayName = "Note D#6", shortDisplayName = "D#6", layout = "MidiNote", offset = 87)] public byte note087;
    [InputControl(name = "note088", displayName = "Note E6",  shortDisplayName = "E6",  layout = "MidiNote", offset = 88)] public byte note088;
    [InputControl(name = "note089", displayName = "Note F6",  shortDisplayName = "F6",  layout = "MidiNote", offset = 89)] public byte note089;
    [InputControl(name = "note090", displayName = "Note F#6", shortDisplayName = "F#6", layout = "MidiNote", offset = 90)] public byte note090;
    [InputControl(name = "note091", displayName = "Note G6",  shortDisplayName = "G6",  layout = "MidiNote", offset = 91)] public byte note091;
    [InputControl(name = "note092", displayName = "Note G#6", shortDisplayName = "G#6", layout = "MidiNote", offset = 92)] public byte note092;
    [InputControl(name = "note093", displayName = "Note A6",  shortDisplayName = "A6",  layout = "MidiNote", offset = 93)] public byte note093;
    [InputControl(name = "note094", displayName = "Note A#6", shortDisplayName = "A#6", layout = "MidiNote", offset = 94)] public byte note094;
    [InputControl(name = "note095", displayName = "Note B6",  shortDisplayName = "B6",  layout = "MidiNote", offset = 95)] public byte note095;
    [InputControl(name = "note096", displayName = "Note C7",  shortDisplayName = "C7",  layout = "MidiNote", offset = 96)] public byte note096;
    [InputControl(name = "note097", displayName = "Note C#7", shortDisplayName = "C#7", layout = "MidiNote", offset = 97)] public byte note097;
    [InputControl(name = "note098", displayName = "Note D7",  shortDisplayName = "D7",  layout = "MidiNote", offset = 98)] public byte note098;
    [InputControl(name = "note099", displayName = "Note D#7", shortDisplayName = "D#7", layout = "MidiNote", offset = 99)] public byte note099;
    [InputControl(name = "note100", displayName = "Note E7",  shortDisplayName = "E7",  layout = "MidiNote", offset = 100)] public byte note100;
    [InputControl(name = "note101", displayName = "Note F7",  shortDisplayName = "F7",  layout = "MidiNote", offset = 101)] public byte note101;
    [InputControl(name = "note102", displayName = "Note F#7", shortDisplayName = "F#7", layout = "MidiNote", offset = 102)] public byte note102;
    [InputControl(name = "note103", displayName = "Note G7",  shortDisplayName = "G7",  layout = "MidiNote", offset = 103)] public byte note103;
    [InputControl(name = "note104", displayName = "Note G#7", shortDisplayName = "G#7", layout = "MidiNote", offset = 104)] public byte note104;
    [InputControl(name = "note105", displayName = "Note A7",  shortDisplayName = "A7",  layout = "MidiNote", offset = 105)] public byte note105;
    [InputControl(name = "note106", displayName = "Note A#7", shortDisplayName = "A#7", layout = "MidiNote", offset = 106)] public byte note106;
    [InputControl(name = "note107", displayName = "Note B7",  shortDisplayName = "B7",  layout = "MidiNote", offset = 107)] public byte note107;
    [InputControl(name = "note108", displayName = "Note C8",  shortDisplayName = "C8",  layout = "MidiNote", offset = 108)] public byte note108;
    [InputControl(name = "note109", displayName = "Note C#8", shortDisplayName = "C#8", layout = "MidiNote", offset = 109)] public byte note109;
    [InputControl(name = "note110", displayName = "Note D8",  shortDisplayName = "D8",  layout = "MidiNote", offset = 110)] public byte note110;
    [InputControl(name = "note111", displayName = "Note D#8", shortDisplayName = "D#8", layout = "MidiNote", offset = 111)] public byte note111;
    [InputControl(name = "note112", displayName = "Note E8",  shortDisplayName = "E8",  layout = "MidiNote", offset = 112)] public byte note112;
    [InputControl(name = "note113", displayName = "Note F8",  shortDisplayName = "F8",  layout = "MidiNote", offset = 113)] public byte note113;
    [InputControl(name = "note114", displayName = "Note F#8", shortDisplayName = "F#8", layout = "MidiNote", offset = 114)] public byte note114;
    [InputControl(name = "note115", displayName = "Note G8",  shortDisplayName = "G8",  layout = "MidiNote", offset = 115)] public byte note115;
    [InputControl(name = "note116", displayName = "Note G#8", shortDisplayName = "G#8", layout = "MidiNote", offset = 116)] public byte note116;
    [InputControl(name = "note117", displayName = "Note A8",  shortDisplayName = "A8",  layout = "MidiNote", offset = 117)] public byte note117;
    [InputControl(name = "note118", displayName = "Note A#8", shortDisplayName = "A#8", layout = "MidiNote", offset = 118)] public byte note118;
    [InputControl(name = "note119", displayName = "Note B8",  shortDisplayName = "B8",  layout = "MidiNote", offset = 119)] public byte note119;
    [InputControl(name = "note120", displayName = "Note C9",  shortDisplayName = "C9",  layout = "MidiNote", offset = 120)] public byte note120;
    [InputControl(name = "note121", displayName = "Note C#9", shortDisplayName = "C#9", layout = "MidiNote", offset = 121)] public byte note121;
    [InputControl(name = "note122", displayName = "Note D9",  shortDisplayName = "D9",  layout = "MidiNote", offset = 122)] public byte note122;
    [InputControl(name = "note123", displayName = "Note D#9", shortDisplayName = "D#9", layout = "MidiNote", offset = 123)] public byte note123;
    [InputControl(name = "note124", displayName = "Note E9",  shortDisplayName = "E9",  layout = "MidiNote", offset = 124)] public byte note124;
    [InputControl(name = "note125", displayName = "Note F9",  shortDisplayName = "F9",  layout = "MidiNote", offset = 125)] public byte note125;
    [InputControl(name = "note126", displayName = "Note F#9", shortDisplayName = "F#9", layout = "MidiNote", offset = 126)] public byte note126;
    [InputControl(name = "note127", displayName = "Note G9",  shortDisplayName = "G9",  layout = "MidiNote", offset = 127)] public byte note127;

    [InputControl(name = "control000", displayName = "Control 0",  shortDisplayName = "CC 0",  layout = "MidiValue", offset = 128)] public byte control000;
    [InputControl(name = "control001", displayName = "Control 1",  shortDisplayName = "CC 1",  layout = "MidiValue", offset = 129)] public byte control001;
    [InputControl(name = "control002", displayName = "Control 2",  shortDisplayName = "CC 2",  layout = "MidiValue", offset = 130)] public byte control002;
    [InputControl(name = "control003", displayName = "Control 3",  shortDisplayName = "CC 3",  layout = "MidiValue", offset = 131)] public byte control003;
    [InputControl(name = "control004", displayName = "Control 4",  shortDisplayName = "CC 4",  layout = "MidiValue", offset = 132)] public byte control004;
    [InputControl(name = "control005", displayName = "Control 5",  shortDisplayName = "CC 5",  layout = "MidiValue", offset = 133)] public byte control005;
    [InputControl(name = "control006", displayName = "Control 6",  shortDisplayName = "CC 6",  layout = "MidiValue", offset = 134)] public byte control006;
    [InputControl(name = "control007", displayName = "Control 7",  shortDisplayName = "CC 7",  layout = "MidiValue", offset = 135)] public byte control007;
    [InputControl(name = "control008", displayName = "Control 8",  shortDisplayName = "CC 8",  layout = "MidiValue", offset = 136)] public byte control008;
    [InputControl(name = "control009", displayName = "Control 9",  shortDisplayName = "CC 9",  layout = "MidiValue", offset = 137)] public byte control009;
    [InputControl(name = "control010", displayName = "Control 10", shortDisplayName = "CC 10", layout = "MidiValue", offset = 138)] public byte control010;
    [InputControl(name = "control011", displayName = "Control 11", shortDisplayName = "CC 11", layout = "MidiValue", offset = 139)] public byte control011;
    [InputControl(name = "control012", displayName = "Control 12", shortDisplayName = "CC 12", layout = "MidiValue", offset = 140)] public byte control012;
    [InputControl(name = "control013", displayName = "Control 13", shortDisplayName = "CC 13", layout = "MidiValue", offset = 141)] public byte control013;
    [InputControl(name = "control014", displayName = "Control 14", shortDisplayName = "CC 14", layout = "MidiValue", offset = 142)] public byte control014;
    [InputControl(name = "control015", displayName = "Control 15", shortDisplayName = "CC 15", layout = "MidiValue", offset = 143)] public byte control015;
    [InputControl(name = "control016", displayName = "Control 16", shortDisplayName = "CC 16", layout = "MidiValue", offset = 144)] public byte control016;
    [InputControl(name = "control017", displayName = "Control 17", shortDisplayName = "CC 17", layout = "MidiValue", offset = 145)] public byte control017;
    [InputControl(name = "control018", displayName = "Control 18", shortDisplayName = "CC 18", layout = "MidiValue", offset = 146)] public byte control018;
    [InputControl(name = "control019", displayName = "Control 19", shortDisplayName = "CC 19", layout = "MidiValue", offset = 147)] public byte control019;
    [InputControl(name = "control020", displayName = "Control 20", shortDisplayName = "CC 20", layout = "MidiValue", offset = 148)] public byte control020;
    [InputControl(name = "control021", displayName = "Control 21", shortDisplayName = "CC 21", layout = "MidiValue", offset = 149)] public byte control021;
    [InputControl(name = "control022", displayName = "Control 22", shortDisplayName = "CC 22", layout = "MidiValue", offset = 150)] public byte control022;
    [InputControl(name = "control023", displayName = "Control 23", shortDisplayName = "CC 23", layout = "MidiValue", offset = 151)] public byte control023;
    [InputControl(name = "control024", displayName = "Control 24", shortDisplayName = "CC 24", layout = "MidiValue", offset = 152)] public byte control024;
    [InputControl(name = "control025", displayName = "Control 25", shortDisplayName = "CC 25", layout = "MidiValue", offset = 153)] public byte control025;
    [InputControl(name = "control026", displayName = "Control 26", shortDisplayName = "CC 26", layout = "MidiValue", offset = 154)] public byte control026;
    [InputControl(name = "control027", displayName = "Control 27", shortDisplayName = "CC 27", layout = "MidiValue", offset = 155)] public byte control027;
    [InputControl(name = "control028", displayName = "Control 28", shortDisplayName = "CC 28", layout = "MidiValue", offset = 156)] public byte control028;
    [InputControl(name = "control029", displayName = "Control 29", shortDisplayName = "CC 29", layout = "MidiValue", offset = 157)] public byte control029;
    [InputControl(name = "control030", displayName = "Control 30", shortDisplayName = "CC 30", layout = "MidiValue", offset = 158)] public byte control030;
    [InputControl(name = "control031", displayName = "Control 31", shortDisplayName = "CC 31", layout = "MidiValue", offset = 159)] public byte control031;
    [InputControl(name = "control032", displayName = "Control 32", shortDisplayName = "CC 32", layout = "MidiValue", offset = 160)] public byte control032;
    [InputControl(name = "control033", displayName = "Control 33", shortDisplayName = "CC 33", layout = "MidiValue", offset = 161)] public byte control033;
    [InputControl(name = "control034", displayName = "Control 34", shortDisplayName = "CC 34", layout = "MidiValue", offset = 162)] public byte control034;
    [InputControl(name = "control035", displayName = "Control 35", shortDisplayName = "CC 35", layout = "MidiValue", offset = 163)] public byte control035;
    [InputControl(name = "control036", displayName = "Control 36", shortDisplayName = "CC 36", layout = "MidiValue", offset = 164)] public byte control036;
    [InputControl(name = "control037", displayName = "Control 37", shortDisplayName = "CC 37", layout = "MidiValue", offset = 165)] public byte control037;
    [InputControl(name = "control038", displayName = "Control 38", shortDisplayName = "CC 38", layout = "MidiValue", offset = 166)] public byte control038;
    [InputControl(name = "control039", displayName = "Control 39", shortDisplayName = "CC 39", layout = "MidiValue", offset = 167)] public byte control039;
    [InputControl(name = "control040", displayName = "Control 40", shortDisplayName = "CC 40", layout = "MidiValue", offset = 168)] public byte control040;
    [InputControl(name = "control041", displayName = "Control 41", shortDisplayName = "CC 41", layout = "MidiValue", offset = 169)] public byte control041;
    [InputControl(name = "control042", displayName = "Control 42", shortDisplayName = "CC 42", layout = "MidiValue", offset = 170)] public byte control042;
    [InputControl(name = "control043", displayName = "Control 43", shortDisplayName = "CC 43", layout = "MidiValue", offset = 171)] public byte control043;
    [InputControl(name = "control044", displayName = "Control 44", shortDisplayName = "CC 44", layout = "MidiValue", offset = 172)] public byte control044;
    [InputControl(name = "control045", displayName = "Control 45", shortDisplayName = "CC 45", layout = "MidiValue", offset = 173)] public byte control045;
    [InputControl(name = "control046", displayName = "Control 46", shortDisplayName = "CC 46", layout = "MidiValue", offset = 174)] public byte control046;
    [InputControl(name = "control047", displayName = "Control 47", shortDisplayName = "CC 47", layout = "MidiValue", offset = 175)] public byte control047;
    [InputControl(name = "control048", displayName = "Control 48", shortDisplayName = "CC 48", layout = "MidiValue", offset = 176)] public byte control048;
    [InputControl(name = "control049", displayName = "Control 49", shortDisplayName = "CC 49", layout = "MidiValue", offset = 177)] public byte control049;
    [InputControl(name = "control050", displayName = "Control 50", shortDisplayName = "CC 50", layout = "MidiValue", offset = 178)] public byte control050;
    [InputControl(name = "control051", displayName = "Control 51", shortDisplayName = "CC 51", layout = "MidiValue", offset = 179)] public byte control051;
    [InputControl(name = "control052", displayName = "Control 52", shortDisplayName = "CC 52", layout = "MidiValue", offset = 180)] public byte control052;
    [InputControl(name = "control053", displayName = "Control 53", shortDisplayName = "CC 53", layout = "MidiValue", offset = 181)] public byte control053;
    [InputControl(name = "control054", displayName = "Control 54", shortDisplayName = "CC 54", layout = "MidiValue", offset = 182)] public byte control054;
    [InputControl(name = "control055", displayName = "Control 55", shortDisplayName = "CC 55", layout = "MidiValue", offset = 183)] public byte control055;
    [InputControl(name = "control056", displayName = "Control 56", shortDisplayName = "CC 56", layout = "MidiValue", offset = 184)] public byte control056;
    [InputControl(name = "control057", displayName = "Control 57", shortDisplayName = "CC 57", layout = "MidiValue", offset = 185)] public byte control057;
    [InputControl(name = "control058", displayName = "Control 58", shortDisplayName = "CC 58", layout = "MidiValue", offset = 186)] public byte control058;
    [InputControl(name = "control059", displayName = "Control 59", shortDisplayName = "CC 59", layout = "MidiValue", offset = 187)] public byte control059;
    [InputControl(name = "control060", displayName = "Control 60", shortDisplayName = "CC 60", layout = "MidiValue", offset = 188)] public byte control060;
    [InputControl(name = "control061", displayName = "Control 61", shortDisplayName = "CC 61", layout = "MidiValue", offset = 189)] public byte control061;
    [InputControl(name = "control062", displayName = "Control 62", shortDisplayName = "CC 62", layout = "MidiValue", offset = 190)] public byte control062;
    [InputControl(name = "control063", displayName = "Control 63", shortDisplayName = "CC 63", layout = "MidiValue", offset = 191)] public byte control063;
    [InputControl(name = "control064", displayName = "Control 64", shortDisplayName = "CC 64", layout = "MidiValue", offset = 192)] public byte control064;
    [InputControl(name = "control065", displayName = "Control 65", shortDisplayName = "CC 65", layout = "MidiValue", offset = 193)] public byte control065;
    [InputControl(name = "control066", displayName = "Control 66", shortDisplayName = "CC 66", layout = "MidiValue", offset = 194)] public byte control066;
    [InputControl(name = "control067", displayName = "Control 67", shortDisplayName = "CC 67", layout = "MidiValue", offset = 195)] public byte control067;
    [InputControl(name = "control068", displayName = "Control 68", shortDisplayName = "CC 68", layout = "MidiValue", offset = 196)] public byte control068;
    [InputControl(name = "control069", displayName = "Control 69", shortDisplayName = "CC 69", layout = "MidiValue", offset = 197)] public byte control069;
    [InputControl(name = "control070", displayName = "Control 70", shortDisplayName = "CC 70", layout = "MidiValue", offset = 198)] public byte control070;
    [InputControl(name = "control071", displayName = "Control 71", shortDisplayName = "CC 71", layout = "MidiValue", offset = 199)] public byte control071;
    [InputControl(name = "control072", displayName = "Control 72", shortDisplayName = "CC 72", layout = "MidiValue", offset = 200)] public byte control072;
    [InputControl(name = "control073", displayName = "Control 73", shortDisplayName = "CC 73", layout = "MidiValue", offset = 201)] public byte control073;
    [InputControl(name = "control074", displayName = "Control 74", shortDisplayName = "CC 74", layout = "MidiValue", offset = 202)] public byte control074;
    [InputControl(name = "control075", displayName = "Control 75", shortDisplayName = "CC 75", layout = "MidiValue", offset = 203)] public byte control075;
    [InputControl(name = "control076", displayName = "Control 76", shortDisplayName = "CC 76", layout = "MidiValue", offset = 204)] public byte control076;
    [InputControl(name = "control077", displayName = "Control 77", shortDisplayName = "CC 77", layout = "MidiValue", offset = 205)] public byte control077;
    [InputControl(name = "control078", displayName = "Control 78", shortDisplayName = "CC 78", layout = "MidiValue", offset = 206)] public byte control078;
    [InputControl(name = "control079", displayName = "Control 79", shortDisplayName = "CC 79", layout = "MidiValue", offset = 207)] public byte control079;
    [InputControl(name = "control080", displayName = "Control 80", shortDisplayName = "CC 80", layout = "MidiValue", offset = 208)] public byte control080;
    [InputControl(name = "control081", displayName = "Control 81", shortDisplayName = "CC 81", layout = "MidiValue", offset = 209)] public byte control081;
    [InputControl(name = "control082", displayName = "Control 82", shortDisplayName = "CC 82", layout = "MidiValue", offset = 210)] public byte control082;
    [InputControl(name = "control083", displayName = "Control 83", shortDisplayName = "CC 83", layout = "MidiValue", offset = 211)] public byte control083;
    [InputControl(name = "control084", displayName = "Control 84", shortDisplayName = "CC 84", layout = "MidiValue", offset = 212)] public byte control084;
    [InputControl(name = "control085", displayName = "Control 85", shortDisplayName = "CC 85", layout = "MidiValue", offset = 213)] public byte control085;
    [InputControl(name = "control086", displayName = "Control 86", shortDisplayName = "CC 86", layout = "MidiValue", offset = 214)] public byte control086;
    [InputControl(name = "control087", displayName = "Control 87", shortDisplayName = "CC 87", layout = "MidiValue", offset = 215)] public byte control087;
    [InputControl(name = "control088", displayName = "Control 88", shortDisplayName = "CC 88", layout = "MidiValue", offset = 216)] public byte control088;
    [InputControl(name = "control089", displayName = "Control 89", shortDisplayName = "CC 89", layout = "MidiValue", offset = 217)] public byte control089;
    [InputControl(name = "control090", displayName = "Control 90", shortDisplayName = "CC 90", layout = "MidiValue", offset = 218)] public byte control090;
    [InputControl(name = "control091", displayName = "Control 91", shortDisplayName = "CC 91", layout = "MidiValue", offset = 219)] public byte control091;
    [InputControl(name = "control092", displayName = "Control 92", shortDisplayName = "CC 92", layout = "MidiValue", offset = 220)] public byte control092;
    [InputControl(name = "control093", displayName = "Control 93", shortDisplayName = "CC 93", layout = "MidiValue", offset = 221)] public byte control093;
    [InputControl(name = "control094", displayName = "Control 94", shortDisplayName = "CC 94", layout = "MidiValue", offset = 222)] public byte control094;
    [InputControl(name = "control095", displayName = "Control 95", shortDisplayName = "CC 95", layout = "MidiValue", offset = 223)] public byte control095;
    [InputControl(name = "control096", displayName = "Control 96", shortDisplayName = "CC 96", layout = "MidiValue", offset = 224)] public byte control096;
    [InputControl(name = "control097", displayName = "Control 97", shortDisplayName = "CC 97", layout = "MidiValue", offset = 225)] public byte control097;
    [InputControl(name = "control098", displayName = "Control 98", shortDisplayName = "CC 98", layout = "MidiValue", offset = 226)] public byte control098;
    [InputControl(name = "control099", displayName = "Control 99", shortDisplayName = "CC 99", layout = "MidiValue", offset = 227)] public byte control099;
    [InputControl(name = "control100", displayName = "Control 100", shortDisplayName = "CC 100", layout = "MidiValue", offset = 228)] public byte control100;
    [InputControl(name = "control101", displayName = "Control 101", shortDisplayName = "CC 101", layout = "MidiValue", offset = 229)] public byte control101;
    [InputControl(name = "control102", displayName = "Control 102", shortDisplayName = "CC 102", layout = "MidiValue", offset = 230)] public byte control102;
    [InputControl(name = "control103", displayName = "Control 103", shortDisplayName = "CC 103", layout = "MidiValue", offset = 231)] public byte control103;
    [InputControl(name = "control104", displayName = "Control 104", shortDisplayName = "CC 104", layout = "MidiValue", offset = 232)] public byte control104;
    [InputControl(name = "control105", displayName = "Control 105", shortDisplayName = "CC 105", layout = "MidiValue", offset = 233)] public byte control105;
    [InputControl(name = "control106", displayName = "Control 106", shortDisplayName = "CC 106", layout = "MidiValue", offset = 234)] public byte control106;
    [InputControl(name = "control107", displayName = "Control 107", shortDisplayName = "CC 107", layout = "MidiValue", offset = 235)] public byte control107;
    [InputControl(name = "control108", displayName = "Control 108", shortDisplayName = "CC 108", layout = "MidiValue", offset = 236)] public byte control108;
    [InputControl(name = "control109", displayName = "Control 109", shortDisplayName = "CC 109", layout = "MidiValue", offset = 237)] public byte control109;
    [InputControl(name = "control110", displayName = "Control 110", shortDisplayName = "CC 110", layout = "MidiValue", offset = 238)] public byte control110;
    [InputControl(name = "control111", displayName = "Control 111", shortDisplayName = "CC 111", layout = "MidiValue", offset = 239)] public byte control111;
    [InputControl(name = "control112", displayName = "Control 112", shortDisplayName = "CC 112", layout = "MidiValue", offset = 240)] public byte control112;
    [InputControl(name = "control113", displayName = "Control 113", shortDisplayName = "CC 113", layout = "MidiValue", offset = 241)] public byte control113;
    [InputControl(name = "control114", displayName = "Control 114", shortDisplayName = "CC 114", layout = "MidiValue", offset = 242)] public byte control114;
    [InputControl(name = "control115", displayName = "Control 115", shortDisplayName = "CC 115", layout = "MidiValue", offset = 243)] public byte control115;
    [InputControl(name = "control116", displayName = "Control 116", shortDisplayName = "CC 116", layout = "MidiValue", offset = 244)] public byte control116;
    [InputControl(name = "control117", displayName = "Control 117", shortDisplayName = "CC 117", layout = "MidiValue", offset = 245)] public byte control117;
    [InputControl(name = "control118", displayName = "Control 118", shortDisplayName = "CC 118", layout = "MidiValue", offset = 246)] public byte control118;
    [InputControl(name = "control119", displayName = "Control 119", shortDisplayName = "CC 119", layout = "MidiValue", offset = 247)] public byte control119;
    [InputControl(name = "control120", displayName = "Control 120", shortDisplayName = "CC 120", layout = "MidiValue", offset = 248)] public byte control120;
    [InputControl(name = "control121", displayName = "Control 121", shortDisplayName = "CC 121", layout = "MidiValue", offset = 249)] public byte control121;
    [InputControl(name = "control122", displayName = "Control 122", shortDisplayName = "CC 122", layout = "MidiValue", offset = 250)] public byte control122;
    [InputControl(name = "control123", displayName = "Control 123", shortDisplayName = "CC 123", layout = "MidiValue", offset = 251)] public byte control123;
    [InputControl(name = "control124", displayName = "Control 124", shortDisplayName = "CC 124", layout = "MidiValue", offset = 252)] public byte control124;
    [InputControl(name = "control125", displayName = "Control 125", shortDisplayName = "CC 125", layout = "MidiValue", offset = 253)] public byte control125;
    [InputControl(name = "control126", displayName = "Control 126", shortDisplayName = "CC 126", layout = "MidiValue", offset = 254)] public byte control126;
    [InputControl(name = "control127", displayName = "Control 127", shortDisplayName = "CC 127", layout = "MidiValue", offset = 255)] public byte control127;

    [InputControl(name = "pitchBend", displayName = "Pitch Bend", shortDisplayName = "P.Bend",
                  layout= "Axis", format = "USHT", defaultState = 0x2000,
                  parameters = "normalize = true, normalizeMax = 0.25000381475, normalizeZero = 0.5")]
    public ushort pitchBend;

    [InputControl(name = "channelPressure", displayName = "Channel Pressure", shortDisplayName = "Ch.Press",
                  layout= "Axis", format = "BYTE",
                  parameters = "normalize = true, normalizeMax = 0.49803921568")]
    public byte channelPressure;

    [InputControl(name = "anyNoteNumber", displayName = "Any Note (Note Number)", shortDisplayName = "AnyNoteNum.",
                  layout= "Axis", format = "BYTE",
                  parameters = "scale = true, scaleFactor = 255")]
    public byte anyNoteNumber;

    [InputControl(name = "anyNoteVelocity", displayName = "Any Note (Velocity)", shortDisplayName = "AnyNoteVel.",
                  layout= "Button", format = "BYTE",
                  parameters = "normalize = true, normalizeMax = 0.49803921568, pressPoint = 0.007874015748")]
    public byte anyNoteVelocity;
}

} // namespace Minis
