using System;
using System.Collections.Generic;
using System.Text;

namespace ShiroNet.Aop
{
    /// <summary>
    /// Base support class for implementations that reads and processes JSR-175 annotations.
    /// @since 0.9.0
    /// </summary>
    public abstract class AnnotationHandler<T> where T: Attribute
    {
        /// <summary>
        /// The type of annotation this handler will process.
        /// </summary>
        protected T annotationClass;

        
        public AnnotationHandler(T annotationClass)
        {
            SetAnnotationClass(annotationClass);
        }

        
        protected Subject GetSubject()
        {
            return SecurityUtils.getSubject();
        }

        
        protected void SetAnnotationClass(T annotationClass)
        {
            if (annotationClass == null) {
                String msg = "annotationClass argument cannot be null";
                throw new IllegalArgumentException(msg);
            }
            this.annotationClass = annotationClass;
        }

    /**
     * Returns the type of annotation this handler inspects and processes.
     *
     * @return the type of annotation this handler inspects and processes.
     */
    public T GetAnnotationClass()
    {
        return this.annotationClass;
    }
}
}
