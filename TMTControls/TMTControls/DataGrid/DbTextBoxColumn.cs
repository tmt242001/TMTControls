﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TMT.Controls.WinForms.DataGrid
{
    public class DbTextBoxColumn : DataGridViewTextBoxColumn, IDbColumn
    {
        public DbTextBoxColumn()
        {
            base.ValueType = typeof(string);
            this.ValidateType = MaskValidateType.None;
            this.CountryCode = "lk";
            this.TabStop = true;
        }

        [Category("Behavior"), DefaultValue(CharacterCasing.Normal)]
        public CharacterCasing CharacterCasing { get; set; }

        [Category("Design"), DefaultValue("lk")]
        public string CountryCode { get; set; }

        [Category("Data"), DefaultValue(false)]
        public bool DataPropertyMandatory { get; set; }

        [Category("Data"), DefaultValue(false)]
        public bool DataPropertyPrimaryKey { get; set; }

        [Category("Data"), DefaultValue(TypeCode.String), RefreshProperties(RefreshProperties.All)]
        public TypeCode DataPropertyType
        {
            get
            {
                return Type.GetTypeCode(base.ValueType);
            }
            set
            {
                base.ValueType = Type.GetType("System." + value);
            }
        }

        [Category("Behavior"), DefaultValue(true)]
        public bool TabStop { get; set; }

        [Category("Design"), DefaultValue(MaskValidateType.None)]
        public MaskValidateType ValidateType { get; set; }

        public override object Clone()
        {
            var that = (DbTextBoxColumn)base.Clone();

            that.DataPropertyType = this.DataPropertyType;
            that.DataPropertyMandatory = this.DataPropertyMandatory;
            that.DataPropertyPrimaryKey = this.DataPropertyPrimaryKey;

            that.ValidateType = this.ValidateType;
            that.CountryCode = this.CountryCode;
            that.TabStop = this.TabStop;
            that.CharacterCasing = this.CharacterCasing;
            return that;
        }
    }
}