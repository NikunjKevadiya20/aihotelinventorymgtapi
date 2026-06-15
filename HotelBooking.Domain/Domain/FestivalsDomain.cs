using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Domain.Validations;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using FluentValidation.Results;

namespace HotelBooking.Domain.Domains
{
    public class FestivalsDomain : IFestivalsDomain
    {
        IFestivalsRepository repository;
        public FestivalsDomain(IFestivalsRepository _repository)
        {
            repository = _repository;
        }

        #region // Insert Added by AI009 on 25-03-23

        public async Task<ResultModel> InsertFestivals(FestivalEntity entity)
        {
            ResultModel result = new ResultModel();
            FestivalsValidator validator = new FestivalsValidator();
            ValidationResult validationResult = validator.Validate(entity);
            if (validationResult.IsValid)
            {
                result = await repository.InsertFestivals(entity);
            }
            else
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                foreach (var item in validationResult.Errors)
                {
                    result.Message += item.ErrorMessage + Environment.NewLine;
                    result.Details += item.ErrorMessage;
                }
            }

            return result;
        }
        #endregion

        #region // Update Added by AI009 on 25-03-23
        public async Task<ResultModel> UpdateFestivals(FestivalEntity entity)
        {
            ResultModel result = new ResultModel();
            FestivalsValidator validator = new FestivalsValidator();
            ValidationResult validationResult = validator.Validate(entity);
            if (validationResult.IsValid)
            {
                result = await repository.UpdateFestivals(entity);
            }
            else
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                foreach (var item in validationResult.Errors)
                {
                    result.Message += item.ErrorMessage + Environment.NewLine;
                    result.Details += item.ErrorMessage;
                }
            }

            return result;

        }
        #endregion

        #region // FindAll Added by AI009 on 25-03-23
        public async Task<List<FestivalsEntity>> FindAllFestivals()
        {
            return await repository.FindAllFestivals();
        }
        #endregion

        #region // FindAllActive Added by AI009 on 25-03-23
        public async Task<List<FestivalsEntity>> FindAllActiveFestivals(string? Title)
        {
            return await repository.FindAllActiveFestivals(Title);
        }
        #endregion

        #region // FindByID Added by AI009 on 25-03-23
        public async Task<FestivalsEntity> FindByIDFestivals(FestivalsViewEntity entity)
        {
            return await repository.FindByIDFestivals(entity);
        }
        #endregion

        #region // Delete Added by AI009 on 25-03-23

        public async Task<ResultModel> DeleteFestivals(FestivalsViewEntity entity)
        {
            return await repository.DeleteFestivals(entity);
        }
        #endregion

        #region // Active-InActive Added by AI009 on 25-03-23
        public async Task<ResultModel> ActiveInActiveFestivals(FestivalsViewEntity entity)
        {
            return await repository.ActiveInActiveFestivals(entity);
        }
        #endregion

    }
}
