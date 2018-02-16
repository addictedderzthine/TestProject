using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public abstract class EntityBase : IValidatable
    {
        private readonly ValidationErrors _validationErrors;

        protected EntityBase() => _validationErrors = new ValidationErrors();
        public bool IsValid
        {
            get
            {
                _validationErrors.Clear();
                Validate();
                return ValidationErrors.Items.Count == 0;
            }
        }
        protected virtual void Validate()
        {

        }

        public ValidationErrors ValidationErrors => _validationErrors;
    }
}
