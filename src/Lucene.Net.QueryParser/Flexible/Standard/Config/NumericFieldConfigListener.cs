﻿using Lucene.Net.QueryParsers.Flexible.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucene.Net.QueryParsers.Flexible.Standard.Config
{
    /// <summary>
    /// This listener is used to listen to {@link FieldConfig} requests in
    /// {@link QueryConfigHandler} and add {@link ConfigurationKeys#NUMERIC_CONFIG}
    /// based on the {@link ConfigurationKeys#NUMERIC_CONFIG_MAP} set in the
    /// {@link QueryConfigHandler}.
    /// </summary>
    /// <seealso cref="NumericConfig"/>
    /// <seealso cref="QueryConfigHandler"/>
    /// <seealso cref="ConfigurationKeys#NUMERIC_CONFIG"/>
    /// <seealso cref="ConfigurationKeys#NUMERIC_CONFIG_MAP"/>
    public class NumericFieldConfigListener : IFieldConfigListener
    {
        private readonly QueryConfigHandler config;

        /**
         * Construcs a {@link NumericFieldConfigListener} object using the given {@link QueryConfigHandler}.
         * 
         * @param config the {@link QueryConfigHandler} it will listen too
         */
        public NumericFieldConfigListener(QueryConfigHandler config)
        {
            if (config == null)
            {
                throw new ArgumentException("config cannot be null!");
            }

            this.config = config;
        }

        public virtual void BuildFieldConfig(FieldConfig fieldConfig)
        {
            IDictionary<string, NumericConfig> numericConfigMap = config
                .Get(ConfigurationKeys.NUMERIC_CONFIG_MAP);

            if (numericConfigMap != null)
            {
                NumericConfig numericConfig;
                if (numericConfigMap.TryGetValue(fieldConfig.Field, out numericConfig) && numericConfig != null)
                {
                    fieldConfig.Set(ConfigurationKeys.NUMERIC_CONFIG, numericConfig);
                }
            }
        }
    }
}