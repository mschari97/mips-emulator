﻿using MIPS_Emulator.Instructions.IType;
using NUnit.Framework;

namespace MIPS_Emulator.Test.Instructions.IType {
	public class SwInstructionTest {
		private uint pc;
		private Registers reg;
		private MemoryMapper mem;
		private SwInstruction target;

		[SetUp]
		public void SetUp() {
			pc = 0x00000000;
			reg = new Registers();
			mem = new MemoryMapper(8);
		}

		[Test]
		public void Execute_DataStoredInMem() {
			reg[8] = 0x11037;
			target = new SwInstruction(8, 9, 0x0004);
			
			target.Execute(ref pc, mem, reg);
			
			Assert.AreEqual(0x11037, mem[4]);
			Assert.AreEqual(0x00000004, pc);
		}

		[Test]
		public void ToString_Formatted() {
			target = new SwInstruction(8, 9, 0x0004);
			
			Assert.AreEqual("SW $t0, 0x0004($t1)", target.ToString());
		}
	}
}