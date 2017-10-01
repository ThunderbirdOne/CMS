using CMS.Data.EF;
using CMS.Data.EF.Entities;
using System;

public class UnitOfWork : IDisposable
{
    private CMSContext context = new CMSContext();

    private GenericRepository<Alias> aliasRepository;
    public GenericRepository<Alias> AliasRepository
    {
        get
        {

            if (this.aliasRepository == null)
            {
                this.aliasRepository = new GenericRepository<Alias>(context);
            }
            return aliasRepository;
        }
    }

    private GenericRepository<Block> blockRepository;
    public GenericRepository<Block> BlockRepository
    {
        get
        {

            if (this.blockRepository == null)
            {
                this.blockRepository = new GenericRepository<Block>(context);
            }
            return blockRepository;
        }
    }

    private GenericRepository<BootstrapBlock> bootstrapBlockRepository;
    public GenericRepository<BootstrapBlock> BootstrapBlockRepository
    {
        get
        {

            if (this.bootstrapBlockRepository == null)
            {
                this.bootstrapBlockRepository = new GenericRepository<BootstrapBlock>(context);
            }
            return bootstrapBlockRepository;
        }
    }

    private GenericRepository<ContentBlock> contentBlockRepository;
    public GenericRepository<ContentBlock> ContentBlockRepository
    {
        get
        {

            if (this.contentBlockRepository == null)
            {
                this.contentBlockRepository = new GenericRepository<ContentBlock>(context);
            }
            return contentBlockRepository;
        }
    }

    private GenericRepository<Page> pageRepository;
    public GenericRepository<Page> PageRepository
    {
        get
        {

            if (this.pageRepository == null)
            {
                this.pageRepository = new GenericRepository<Page>(context);
            }
            return pageRepository;
        }
    }

    private GenericRepository<PageType> pageTypeRepository;
    public GenericRepository<PageType> PageTypeRepository
    {
        get
        {

            if (this.pageTypeRepository == null)
            {
                this.pageTypeRepository = new GenericRepository<PageType>(context);
            }
            return pageTypeRepository;
        }
    }

    private GenericRepository<PropertyValue> propertyValueRepository;
    public GenericRepository<PropertyValue> PropertyValueRepository
    {
        get
        {

            if (this.propertyValueRepository == null)
            {
                this.propertyValueRepository = new GenericRepository<PropertyValue>(context);
            }
            return propertyValueRepository;
        }
    }

    public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}