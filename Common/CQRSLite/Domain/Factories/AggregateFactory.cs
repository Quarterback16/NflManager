﻿using System;
using Common.CQRSlite.Domain.Exception;

namespace Common.CQRSlite.Domain.Factories
{
	internal static class AggregateFactory
	{
		public static T CreateAggregate<T>()
		{
			try
			{
				return ( T ) Activator.CreateInstance( typeof( T ), true );
			}
			catch ( MissingMethodException )
			{
				throw new MissingParameterLessConstructorException( typeof( T ) );
			}
		}
	}
}
