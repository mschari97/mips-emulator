﻿using System;
using System.Collections.Generic;

namespace MIPS_Emulator {
	public class Mips {
		private uint pc;
		public IDictionary<Type, List<MemoryUnit>> MemDict;

		public uint Pc => pc;
		public InstructionMemory InstrMem { get; }
		public MemoryMapper Memory { get; }
		public Registers Reg { get; }
		public string Name { get; set; }
		public float ClockSpeed { get; set; }

		public Mips(uint pc, IDictionary<Type, List<MemoryUnit>> memDict, Registers reg = null, string name = "", float clockSpeed = 0) {
			this.pc = pc;
			this.MemDict = memDict;
			this.InstrMem = (InstructionMemory) memDict[typeof(InstructionMemory)][0];
			this.Memory = (MemoryMapper) memDict[typeof(MemoryMapper)][0];
			this.Reg = reg ?? new Registers();
			this.Name = name;
			this.ClockSpeed = clockSpeed;
		}

		public void ExecuteNext() {
			InstrMem.GetInstruction(pc).Execute(ref pc, Memory, Reg);
		}

		public void ExecuteAll() {
			while (pc < InstrMem.Size) {
				InstrMem.GetInstruction(pc).Execute(ref pc, Memory, Reg);
			}
		}
	}
}