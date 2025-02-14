using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class SkillStepConfigCategory : ProtoObject, IMerge
    {
        public static SkillStepConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, SkillStepConfig> dict = new Dictionary<int, SkillStepConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<SkillStepConfig> list = new List<SkillStepConfig>();
		
        public SkillStepConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            SkillStepConfigCategory s = o as SkillStepConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            for(int i =0 ;i<list.Count;i++)
            {
                SkillStepConfig config = list[i];
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public SkillStepConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillStepConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillStepConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillStepConfig> GetAll()
        {
            return this.dict;
        }
        public List<SkillStepConfig> GetAllList()
        {
            return this.list;
        }
        public SkillStepConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class SkillStepConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>参数数量</summary>
		[ProtoMember(2)]
		public int ParaCount { get; set; }
		/// <summary>时间节点0</summary>
		[ProtoMember(3)]
		public int TriggerTime0 { get; set; }
		/// <summary>步骤类型0</summary>
		[ProtoMember(4)]
		public int StepStyle0 { get; set; }
		/// <summary>步骤参数0</summary>
		[ProtoMember(5)]
		public string[] StepParameter0 { get; set; }
		/// <summary>是否可打断0</summary>
		[ProtoMember(6)]
		public int CanInterrupt0 { get; set; }
		/// <summary>时间节点1</summary>
		[ProtoMember(7)]
		public int TriggerTime1 { get; set; }
		/// <summary>步骤类型1</summary>
		[ProtoMember(8)]
		public int StepStyle1 { get; set; }
		/// <summary>步骤参数1</summary>
		[ProtoMember(9)]
		public string[] StepParameter1 { get; set; }
		/// <summary>是否可打断1</summary>
		[ProtoMember(10)]
		public int CanInterrupt1 { get; set; }
		/// <summary>时间节点2</summary>
		[ProtoMember(11)]
		public int TriggerTime2 { get; set; }
		/// <summary>步骤类型2</summary>
		[ProtoMember(12)]
		public int StepStyle2 { get; set; }
		/// <summary>步骤参数2</summary>
		[ProtoMember(13)]
		public string[] StepParameter2 { get; set; }
		/// <summary>是否可打断2</summary>
		[ProtoMember(14)]
		public int CanInterrupt2 { get; set; }
		/// <summary>时间节点3</summary>
		[ProtoMember(15)]
		public int TriggerTime3 { get; set; }
		/// <summary>步骤类型3</summary>
		[ProtoMember(16)]
		public int StepStyle3 { get; set; }
		/// <summary>步骤参数3</summary>
		[ProtoMember(17)]
		public string[] StepParameter3 { get; set; }
		/// <summary>是否可打断3</summary>
		[ProtoMember(18)]
		public int CanInterrupt3 { get; set; }
		/// <summary>时间节点4</summary>
		[ProtoMember(19)]
		public int TriggerTime4 { get; set; }
		/// <summary>步骤类型4</summary>
		[ProtoMember(20)]
		public int StepStyle4 { get; set; }
		/// <summary>步骤参数4</summary>
		[ProtoMember(21)]
		public string[] StepParameter4 { get; set; }
		/// <summary>是否可打断4</summary>
		[ProtoMember(22)]
		public int CanInterrupt4 { get; set; }
		/// <summary>时间节点5</summary>
		[ProtoMember(23)]
		public int TriggerTime5 { get; set; }
		/// <summary>步骤类型5</summary>
		[ProtoMember(24)]
		public int StepStyle5 { get; set; }
		/// <summary>步骤参数5</summary>
		[ProtoMember(25)]
		public string[] StepParameter5 { get; set; }
		/// <summary>是否可打断5</summary>
		[ProtoMember(26)]
		public int CanInterrupt5 { get; set; }

	}
}
