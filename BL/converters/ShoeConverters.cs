using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.converters
{
	public class ShoeConverter
	{
		public static ShoeDTO ShoeToDTO(Sho shoe)
		{
			return new ShoeDTO
			{
				id_shoe = shoe.id_shoe,
				model = shoe.model,
				picture = shoe.picture,
				kind = shoe.kind,
				price = shoe.price,
				from_size = shoe.from_size,
				to_size = shoe.to_size
			};
		}
		public static Sho ShoeToDAL(ShoeDTO shoe)
		{ 
				return new Sho
			{
				id_shoe = shoe.id_shoe,
				model = shoe.model,
				picture = shoe.picture,
				kind = shoe.kind,
				price = shoe.price,
				from_size = shoe.from_size,
				to_size = shoe.to_size
			};
		}

		public static List<ShoeDTO> ShoeListToDTO(List<Sho> ShoesList)
		{
			List<ShoeDTO> DTOlist = new List<ShoeDTO>();

			return ShoesList.Select(s => ShoeToDTO(s)).ToList();
		}
	}
}
