using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.ActionAndBenefits.Contracts.Repository;
using MQuince.ActionAndBenefits.Contracts.Service;
using MQuince.ActionAndBenefits.Domain;
using MQuince.ActionAndBenefits.Services;
using MQuince.Core.IdentifiableDTO;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MQuince.Integration.HospitalApp.Tests.ServiceTests
{
	public class ActionAndBenefitsServiceTests
	{
		IActionAndBenefitsService actionAndBenefitsService;
		IActionAndBenefitsRepository actionAndBenefitsRepository = Substitute.For<IActionAndBenefitsRepository>();

		public ActionAndBenefitsServiceTests()
		{
			actionAndBenefitsService = new ActionAndBenefitsService(actionAndBenefitsRepository);
		}

		[Fact]
		public void Constructor_when_give_repository_as_null()
		{
			Assert.Throws<ArgumentNullException>(() => new ActionAndBenefitsService(null));
		}

		[Fact]
		public void Constructor_when_give_correctly_repository()
		{
			IActionAndBenefitsService workTimeService = new ActionAndBenefitsService(actionAndBenefitsRepository);

			Assert.IsType<ActionAndBenefitsService>(workTimeService);
		}

		[Fact]
		public void Get_all_returns_data()
		{
			actionAndBenefitsRepository.GetAll().Returns(this.GetListOfActionAndBenefits());

			List<IdentifiableDTO<ActionAndBenefitsDTO>> returnedList = actionAndBenefitsService.GetAll().ToList();

			Assert.Equal(2, returnedList.Count);
		}



		private bool CompareActionAndBenefitsAndIdentifierActionAndBenefits(ActionsAndBenefits actionAndBenefits, IdentifiableDTO<ActionAndBenefitsDTO> actionAndBenefitsDTO)
		{
			if (actionAndBenefits.IDAction != actionAndBenefitsDTO.Id)
				return false;

			if (!actionAndBenefits.PharmacyName.Equals(actionAndBenefitsDTO.EntityDTO.PharmacyName))
				return false;

			if (!actionAndBenefits.ActionName.Equals(actionAndBenefitsDTO.EntityDTO.ActionName))
				return false;

			if (actionAndBenefits.DateRange.StartDateTime != actionAndBenefitsDTO.EntityDTO.BeginDate)
				return false;

			if (actionAndBenefits.DateRange.EndDateTime != actionAndBenefitsDTO.EntityDTO.EndDate)
				return false;

			if (actionAndBenefits.Price.OldPrice != actionAndBenefitsDTO.EntityDTO.OldCost)
				return false;

			if (actionAndBenefits.Price.NewPrice != actionAndBenefitsDTO.EntityDTO.NewCost)
				return false;
			if (actionAndBenefits.IsApproved != actionAndBenefitsDTO.EntityDTO.IsApproved)
				return false;

			return true;
		}


		private List<ActionsAndBenefits> GetListOfActionAndBenefits()
		{
			List<ActionsAndBenefits> listOfActionAndBenefits = new List<ActionsAndBenefits>();
			listOfActionAndBenefits.Add(this.GetFirstActionAndBenefits());
			listOfActionAndBenefits.Add(this.GetSecondtActionAndBenefits());
			return listOfActionAndBenefits;
		}

		private ActionsAndBenefits GetFirstActionAndBenefits()
			=> new ActionsAndBenefits(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"),
									 "Zegin",
									 "Propamicin sada samo za 40% popusta",
									 new DateTime(2020, 12, 29),
									 new DateTime(2021, 01, 20),
									 400,
									 240,
									 false);
		private ActionsAndBenefits GetSecondtActionAndBenefits()
			 => new ActionsAndBenefits(Guid.Parse("52d5a046-bc14-4cce-9ab0-222565f50526"),
									  "Jankovic",
									  "Analgin 10%",
									  new DateTime(2020, 12, 23),
									  new DateTime(2021, 01, 11),
									  310,
									  290,
									  true);
	}
}
