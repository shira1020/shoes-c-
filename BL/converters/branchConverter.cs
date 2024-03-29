﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL.converters
{
  public  class branchConverter
    {
        public static branchDetails ConvertToBranchDTO(Branch branch)
        {
            return new branchDetails { name=branch.name_branch ,adress=branch.city+' '+ branch.street+' '+branch.house_number,mapLink=branch.mapLink };
        }

        public static List<branchDetails> BranchListToDTO(List<Branch> BranchList)
        {
            List<branchDetails> DTOlist = new List<branchDetails>();

            return BranchList.Select(b => ConvertToBranchDTO(b)).ToList();
        }
    }
}
